using System;
using System.Net.Sockets;
using API.Database.DuckSoup;
using PacketLibrary.Handler;
using Serilog;
using SilkroadSecurityAPI;
using SilkroadSecurityAPI.Message;
using TcpClient = NetCoreServer.TcpClient;

namespace DuckSoup.Library.Server;

/// <summary>
///     Basically the connection to the Server, the proxy spawns a client that connects to the Silkroad Server
/// </summary>
public class FakeClient : TcpClient
{
    public FakeClient(FakeServer fakeServer, Service service) : base(service.RemoteMachine_Machine.Address,
        service.RemotePort)
    {
        ServerSecurity = Utility.GetSecurity(service.SecurityType);
        FakeServer = fakeServer;
    }

    public ISession Session { get; internal set; }
    private ISecurity ServerSecurity { get; }
    private FakeServer FakeServer { get; }

    protected override void OnConnected()
    {
        Log.Debug($"FakeRemoteClient connected a new session with Id {Id}");
    }

    protected override void OnDisconnected()
    {
        Log.Debug($"FakeRemoteClient disconnected a session with Id {Id}");
        Session.Disconnect();
    }

    protected override void OnError(SocketError error)
    {
        Log.Debug($"FakeRemoteClient caught an error with code {error}");
        Session.Disconnect();
    }

    // Receive from Server
    // S -> P -> C
    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        try
        {
            ServerSecurity.Recv(buffer, (int)offset, (int)size);

            var receivedPackets = ServerSecurity.TransferIncoming();

            if (receivedPackets == null || receivedPackets.Count == 0) return;

            foreach (var packet in receivedPackets)
            {
                
                var packetType = packet.Encrypted ? "[E]" : packet.Massive ? "[M]" : "";
                var message = $"[S -> P] {packetType} Packet: 0x{packet.MsgId:X} - {Id}";
                Log.Debug(message);

                if (packet.MsgId == 0x5000 || packet.MsgId == 0x9000) continue;

                var packetResult = FakeServer.PacketHandler.HandleServer(packet, Session).Result;

                switch (packetResult.ResultType)
                {
                    case PacketResultType.Block:
                        // TODO :: Temporary for testing purp.
                        // Session.SendToClient(packetResult);
                        Console.WriteLine($"Server Packet: 0x{packet.MsgId:X} is perhaps not on whitelist!");
                        break;
                    case PacketResultType.Disconnect:
                        // Console.WriteLine($"Packet: 0x{packet.MsgId:X} is on blacklist!");
                        Session.Disconnect();
                        return;
                    case PacketResultType.Nothing:
                        Session.SendToClient(packetResult);
                        break;
                    default:
                        Log.Error("FakeClient - Unknown ResultType");
                        break;
                }
            }

            Session.TransferToClient();
        }
        catch (Exception exception)
        {
            Log.Error("FakeClient Recv | {0}", exception.Message);
            Log.Error("FakeClient Recv | {0}", exception.StackTrace);
            Session.Disconnect();
        }
    }

    public void Send(Packet packet, bool transfer = false)
    {
        ServerSecurity.Send(packet);

        if (transfer) Transfer();
    }

    public void Transfer()
    {
        ServerSecurity.TransferOutgoing(this);
    }
}