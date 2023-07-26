using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class MaxCurAttempts
{
    public readonly uint CurAttempts;
    public readonly uint MaxAttempts;

    public MaxCurAttempts(Packet packet)
    {
        packet.TryRead(out MaxAttempts)
            .TryRead(out CurAttempts);

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
        packet.TryWrite(MaxAttempts)
            .TryWrite(CurAttempts);

        // packet.WriteUInt32(MaxAttempts);
        // packet.WriteUInt32(CurAttempts);
        return packet;
    }
}