using System.Collections.Concurrent;
using NetCoreServer;
using SilkroadSecurityFake.ByteBuff;
using SilkroadSecurityFake.Packets;
using Buffer = System.Buffer;

namespace SilkroadSecurityFake.Security;

/// <summary>
/// Security between the Proxy and the Client, always look from the proxy perspective and ask yourself "who is the proxy talking to?"
/// </summary>
public class ClientSecurity : Security
{
    public override Task Receive(byte[] buffer, long offset, long size)
    {
        var packet = Packet.Rent();
        packet.SetInitialData(buffer, size);
        if ((packet.Size & 0x8000) > 0)
        {
            packet.SetEncrypted(true);
            return HandleEncrypted(packet);
        }
        
        if(packet.MsgId == 0x600D)
        {
            return HandleMassive(packet);
        }

        return HandleRaw(packet);
    }
    
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

    /// <summary>
    /// Do not implement. It is implemented in <see cref="ServerSecurity"/>
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override void TransferOutgoing(TcpClient client)
    {
        throw new NotImplementedException();
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