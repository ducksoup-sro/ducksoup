using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NetCoreServer;
using SilkroadSecurityFake.ByteBuff;
using SilkroadSecurityFake.Packets;

namespace SilkroadSecurityFake.Security;

public abstract class Security
{
    #region BlowFish

    private Blowfish.Blowfish Blowfish { get; }

    #endregion
    
    #region Massive
    protected Packet? MassivePacket { get; set; }
    protected ushort MassiveCount { get; set; }
    #endregion

    #region PacketFlow
    protected ConcurrentQueue<Packet> IncomingPackets { get; }
    protected ConcurrentQueue<Packet> OutgoingPackets { get; }
    #endregion

    #region Handshake
    private bool AcceptedHandshake { get; set; }

    #endregion
    
    protected Security()
    {
        Blowfish = new Blowfish.Blowfish();
        IncomingPackets = new ConcurrentQueue<Packet>();
        OutgoingPackets = new ConcurrentQueue<Packet>();
    }

    public abstract Task Receive(byte[] buffer, long offset, long size);
    public abstract void TransferOutgoing(TcpSession session);
    public abstract void TransferOutgoing(TcpClient client);
    public abstract ConcurrentQueue<Packet> TransferIncoming();
    public abstract void Send(Packet packet);

    protected Task HandleEncrypted(Packet packet)
    {
        var buff = BuffPool.Rent(BuffSize.Buff4K);
        buff.Write(packet.Buffer);
        packet.Return();
        var realSize = (ushort)(buff.Buffer.ToArray()[1] << 8 | buff.Buffer.ToArray()[0] | 0x8000)
        MemoryMarshal.Write(buff.Buffer.Span.Slice(0, Unsafe.SizeOf<ushort>()), ref realSize);
        
            
        throw new NotImplementedException();
        return Task.CompletedTask;
    }
    
    protected Task HandleMassive(Packet packet)
    {
        packet.TryRead<byte>(out var mode);
        if (mode != 0x01 && MassivePacket == null)
        {
            MassiveCount = 0;
            throw new Exception(
                "[SecurityAPI::HandleMassive] A malformed 0x600D packet was received.");
        }

        if (mode == 0x01)
        {
            packet.TryRead<ushort>(out var msgId);
            packet.TryRead<ushort>(out var count);
            MassiveCount = count;
            MassivePacket = PacketPool.Rent();
            MassivePacket.TryWrite(msgId);
            MassivePacket.SetEncrypted(packet.Encrypted);
            return Task.CompletedTask;
        }

        
        foreach (var b in packet.Data.ToArray())
        {
            MassivePacket!.TryWrite(b); // this cannot be null since we check stuff above
        }

        MassiveCount--;
        if (MassiveCount == 0)
        {
            IncomingPackets.Enqueue(MassivePacket!);
            MassivePacket = null;
        }

        return Task.CompletedTask;
    }

    protected Task HandleRaw(Packet packet)
    {
        IncomingPackets.Enqueue(packet);
        return Task.CompletedTask;
    }
    
    protected bool HasPacketToSend()
    {
        // No packets, easy case
        if (OutgoingPackets.Count == 0)
        {
            return false;
        }

        // If we have packets and have accepted the handshake, we can send whenever,
        // so return true.
        
        if (AcceptedHandshake)
        {
            return true;
        }

        // Otherwise, check to see if we have pending handshake packets to send
        var packet = OutgoingPackets.First();
        if (packet.MsgId == 0x5000 || packet.MsgId == 0x9000)
        {
            return true;
        }

        // If we get here, we have out of order packets that cannot be sent yet.
        return false;
    }

}