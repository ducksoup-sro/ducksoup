using System;
using System.Net.Sockets;
using API.Database.DuckSoup;
using DuckSoup.Library.Session;
using NetCoreServer;
using PacketLibrary.Handler;
using Serilog;
using SilkroadSecurityAPI;
using SilkroadSecurityAPI.Exceptions;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Server;

/// <summary>
///     Basically the connection to the Client, the proxy spawns a server <see cref="FakeServer" /> that accepts
///     connections.
///     After a successfully established connection it will spawn a Session, this.
/// </summary>
public class FakeSession : TcpSession
{
    public FakeSession(FakeServer server, Service service) : base(server)
    {
        FakeServer = server;

        ClientSecurity = Utility.GetSecurity(service.SecurityType);
        ClientSecurity.GenerateSecurity(true, true, true);

        var fakeRemoteClient = new FakeClient(server, service);
        fakeRemoteClient.ConnectAsync();

        Session = new DuckSession(this, fakeRemoteClient);
        fakeRemoteClient.Session = Session;
    }

    public ISession Session { get; }
    private ISecurity ClientSecurity { get; }
    private FakeServer FakeServer { get; }

    protected override void OnConnected()
    {
        Console.WriteLine($"FakeSession connected with Id {Id} connected!");
        FakeServer.AddSession(Session);
    }

    protected override void OnDisconnected()
    {
        FakeServer.RemoveSession(Session);
        Console.WriteLine($"FakeSession disconnected with Id {Id} disconnected!");
        Session.Disconnect();
    }

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"FakeSession caught an error with code {error}");
        Session.Disconnect();
    }

    // Receive from Client
    // C -> P -> S
    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        Session.GetData(DataConstants.CrcFailure, out var crc, 0);
        if (crc > 5)
        {
            Session.Disconnect();
            return;
        }
        
        try
        {
            ClientSecurity.Recv(buffer, (int)offset, (int)size);

            var receivedPackets = ClientSecurity.TransferIncoming();

            if (receivedPackets == null || receivedPackets.Count == 0) return;

            foreach (var packet in receivedPackets)
            {
                // Console.Write("[C -> P]");
                // if (packet.Encrypted)
                //     Console.Write("[E]");
                // if (packet.Massive)
                //     Console.Write("[M]");
                // Console.WriteLine($" Packet: 0x{packet.MsgId:X} - {Id}");

                if (packet.MsgId == 0x5000 || packet.MsgId == 0x9000 || packet.MsgId == 0x2001) continue;

                var packetResult = FakeServer.PacketHandler.HandleClient(packet, Session).Result;

                switch (packetResult.ResultType)
                {
                    case PacketResultType.Block:
                        // TODO :: Temporary for testing purp.
                        // Session.SendToServer(packetResult);
                        Console.WriteLine($"Client Packet: 0x{packet.MsgId:X} is perhaps not on whitelist!");
                        break;
                    case PacketResultType.Disconnect:
                        // Console.WriteLine($"Packet: 0x{packet.MsgId:X} is on blacklist!");
                        Session.Disconnect();
                        return;
                    case PacketResultType.Nothing:
                        Session.SendToServer(packetResult);
                        break;
                    default:
                        Log.Error("FakeSession - Unknown ResultType");
                        break;
                }
            }
            Session.SetData(DataConstants.CrcFailure, 0);
            Session.TransferToServer();
        }
        catch (RecvException recvException)
        {
            Session.SetData(DataConstants.CrcFailure, crc + 1);
        }
        catch (Exception exception)
        {
            Log.Error("FakeSession Recv | {0}", exception.Message);
            Log.Error("FakeSession Recv | {0}", exception.StackTrace);
            Session.Disconnect();
        }
    }

    public void Send(Packet packet, bool transfer = false)
    {
        ClientSecurity.Send(packet);

        if (transfer) Transfer();
    }

    public void Transfer()
    {
        ClientSecurity.TransferOutgoing(this);
    }
}