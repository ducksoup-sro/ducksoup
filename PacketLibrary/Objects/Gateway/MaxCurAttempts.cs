using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class MaxCurAttempts
{
    public uint MaxAttempts { get; set; }
    public uint CurAttempts { get; set; }

    public MaxCurAttempts(Packet packet)
    {
        MaxAttempts = packet.ReadUInt32(); // 4   uint    MaxAttempts
        CurAttempts = packet.ReadUInt32(); // 4   uint    CurAttempts
    }
    
    public MaxCurAttempts(uint maxAttempts, uint curAttempts)
    {
        MaxAttempts = maxAttempts;
        CurAttempts = curAttempts;
    }

    public Packet build(Packet packet)
    {
        packet.WriteUInt32(MaxAttempts);
        packet.WriteUInt32(CurAttempts);

        return packet;
    }
}