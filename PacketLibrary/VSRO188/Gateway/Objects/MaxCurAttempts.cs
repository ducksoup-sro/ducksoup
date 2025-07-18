using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class MaxCurAttempts
{
    public readonly uint CurAttempts;
    public readonly uint MaxAttempts;

    public MaxCurAttempts(Packet packet)
    {
        packet.TryRead<uint>(out MaxAttempts)
            .TryRead<uint>(out CurAttempts);

        // MaxAttempts = packet.ReadUInt32(); // 4   uint    MaxAttempts
        // CurAttempts = packet.ReadUInt32(); // 4   uint    CurAttempts
    }

    public MaxCurAttempts(uint maxAttempts, uint curAttempts)
    {
        MaxAttempts = maxAttempts;
        CurAttempts = curAttempts;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite<uint>(MaxAttempts)
            .TryWrite<uint>(CurAttempts);

        // packet.WriteUInt32(MaxAttempts);
        // packet.WriteUInt32(CurAttempts);
        return packet;
    }
}