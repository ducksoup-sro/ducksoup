using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_JOB_UPDATE_EXP : Packet
{
    public TriJobType TriJobType; 
    public byte JobLevel;
    public uint JobExp;
    
    public SERVER_JOB_UPDATE_EXP() : base(0x30E6)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out TriJobType);
        TryRead(out JobLevel);
        TryRead(out JobExp);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(TriJobType);
        TryWrite(JobLevel);
        TryWrite(JobExp);
        return this;
    }

    public static Packet of()
    {
        return new SERVER_JOB_UPDATE_EXP();
    }
}