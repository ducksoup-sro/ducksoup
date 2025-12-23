using System;
using System.Collections.Generic;
using System.Net.Sockets;
using API.Database.DuckSoup;
using API.EventFactory;
using API.Session;
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
        try
        {
            ClientSecurity = Utility.GetSecurity(service.SecurityType);
            ClientSecurity.GenerateSecurity(true, true, true);

            FakeClient fakeRemoteClient = new FakeClient(server, service);
            fakeRemoteClient.ConnectAsync();

            Session = new DuckSession(this, fakeRemoteClient);
            fakeRemoteClient.Session = Session;
        }
        catch (Exception exception)
        {
            Log.Error("FakeSession | Could not establish remote client");
            Log.Error("FakeSession | {0}", exception.Message);
            Log.Error("FakeSession | {0}", exception.StackTrace);
            Log.Error("FakeSession | {0}", exception.InnerException);
            Log.Error("FakeSession | {0}", exception.Data);
            base.Disconnect();
        }

    }

    public ISession? Session { get; }
    internal ISecurity ClientSecurity { get; }
    private FakeServer FakeServer { get; }

    protected override void OnConnected()
    {
        if (Session == null)
        {
            return;
        }

        Log.Debug($"FakeSession connected with Id {Id} connected!");
        FakeServer.AddSession(Session);
    }

    protected override void OnDisconnected()
    {
        if (Session == null)
        {
            return;
        }

        Session.Disconnect();
        FakeServer.RemoveSession(Session);
        Log.Debug($"FakeSession disconnected with Id {Id} disconnected!");
    }

    protected override void OnError(SocketError error)
    {
        if (Session == null)
        {
            return;
        }

        Session.Disconnect();
        Console.WriteLine($"FakeSession caught an error with code {error}");
    }

    // Receive from Client
    // C -> P -> S
    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        if (Session == null)
        {
            return;
        }

        Session.GetData(Data.CrcFailure, out int crc, 0);
        if (crc > 5)
        {
            Session.Disconnect();
            return;
        }

        string message = string.Empty;
        try
        {
            ClientSecurity.Recv(buffer, (int)offset, (int)size);

            List<Packet>? receivedPackets = ClientSecurity.TransferIncoming();

            if (receivedPackets == null || receivedPackets.Count == 0) return;

            foreach (Packet packet in receivedPackets)
            {
                string packetType = packet.Encrypted ? "[E]" : packet.Massive ? "[M]" : "";
                message = $"[C -> P] {packetType} Packet: 0x{packet.MsgId:X} - {Id}";
                Log.Verbose(message);

                if (EventFactory.HasSubscriptions(EventFactoryNames.OnClientReceivePacket))
                {
                    EventFactory.Publish(EventFactoryNames.OnClientReceivePacket, DateTime.Now, FakeServer.Service.ServerType, Session, new Packet(packet));
                }

                if (packet.MsgId == 0x5000 || packet.MsgId == 0x9000 || packet.MsgId == 0x2001) continue;

                Packet packetResult = FakeServer.PacketHandler.HandleClient(packet, Session).Result;

                switch (packetResult.ResultType)
                {
                    case PacketResultType.Block:
                        // TODO :: Temporary for testing purp.
                        // Session.SendToServer(packetResult);
                        Log.Debug($"Client Packet: 0x{packet.MsgId:X} is perhaps not on whitelist!");
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

            Session.SetData(Data.CrcFailure, 0);
            Session.TransferToServer();
        }
        catch (RecvException recvException)
        {
            Session.SetData(Data.CrcFailure, crc + 1);
        }
        catch (Exception exception)
        {
            Session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            Session.GetData(Data.CharId, out int charId, -1);
            Log.Error("FakeSession Recv | 0x{0:X} | Name: {1} | Id: {2} | ServerType: {3} ", message, charInfo != null ? charInfo.CharName : "null", charId, FakeServer.Service.ServerType);
            Log.Error("FakeSession Recv | SSAClientId: {1} | Current: {2} | Last: {3} ", Session.GetServerSecurity().GetId(), Session.GetServerSecurity().GetCurrentLockState(), Session.GetServerSecurity().GetLastLockState());
            Log.Error("FakeSession Recv | SSAServerId: {1} | Current: {2} | Last: {3} ", Session.GetClientSecurity().GetId(), Session.GetClientSecurity().GetCurrentLockState(), Session.GetClientSecurity().GetLastLockState());
            Log.Error("FakeSession Recv | {0}", exception.Message);
            Log.Error("FakeSession Recv | {0}", exception.StackTrace);
            Log.Error("FakeSession Recv | {0}", exception.InnerException);
            Log.Error("FakeSession Recv | {0}", exception.Data);
            Session.Disconnect();
            EventFactory.Publish(EventFactoryNames.OnSessionDisconnect, charId);
        }
    }

    public void Send(Packet packet, bool transfer = false)
    {
        try
        {
            ClientSecurity.Send(packet);

            if (EventFactory.HasSubscriptions(EventFactoryNames.OnClientTransferPacket))
            {
                EventFactory.Publish(EventFactoryNames.OnClientTransferPacket, DateTime.Now, FakeServer.Service.ServerType, Session, new Packet(packet));
            }

            if (transfer) Transfer();
        }
        catch (Exception exception)
        {
            Log.Error("FakeSession:166 | ID: {0} ", Id);
            Log.Error("FakeSession:166 | {0}", exception.Message);
            Log.Error("FakeSession:166 | {0}", exception.StackTrace);
            Log.Error("FakeSession:166 | {0}", exception.InnerException);
            Log.Error("FakeSession:166 | {0}", exception.Data);
            Disconnect();
        }
    }

    public void Transfer()
    {
        try
        {
            ClientSecurity.TransferOutgoing(this);
        }
        catch (Exception exception)
        {
            Log.Error("FakeSession:181 | ID: {0} ", Id);
            Log.Error("FakeSession:181 | {0}", exception.Message);
            Log.Error("FakeSession:181 | {0}", exception.StackTrace);
            Log.Error("FakeSession:181 | {0}", exception.InnerException);
            Log.Error("FakeSession:181 | {0}", exception.Data);
            Disconnect();
        }
    }
}