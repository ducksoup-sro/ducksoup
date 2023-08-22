using System.Collections.Concurrent;
using NetCoreServer;
using SilkroadSecurityFake.Packets;

namespace SilkroadSecurityFake.Security;

/// <summary>
/// Security between the Proxy and the Server, always look from the proxy perspective and ask yourself "who is the proxy talking to?"
/// </summary>
public class ServerSecurity : Security
{
    public override Task Receive(byte[] buffer, long offset, long size)
    {
        var packet = PacketPool.Rent()
            .SetInitialData(buffer, size);

        if (packet.MsgId == 0x600D)
        {
            HandleMassive(packet);
        }
    }

    /// <summary>
    /// Do not implement. It is implemented in <see cref="ClientSecurity"/>
    /// </summary>
    /// <param name="session"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override void TransferOutgoing(TcpSession session)
    {
        if (!HasPacketToSend())
        {
            return;
        }
        
        while (OutgoingPackets.TryDequeue(out var packet))
        {
            if (packet.Encrypted)
            {
                session.Send(packet.Buffer);
                packet.Return();
                continue;
            }

            if (packet.Massive)
            {
                session.Send(packet.Buffer);
                packet.Return();
                continue;
            }
            
            session.Send(packet.Buffer);
            packet.Return();
        }
    }

    public override void TransferOutgoing(TcpClient client)
    {
        // client.Send();
    }

    public override ConcurrentQueue<Packet> TransferIncoming()
    {
        var result = new ConcurrentQueue<Packet>();

        foreach (var packet in IncomingPackets)
        {
            result.Enqueue(packet);
        }
        
        return result;
    }

    public override void Send(Packet packet)
    {
        // TODO :: Implement
        OutgoingPackets.Enqueue(packet);
    }
}