using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_SKILL_MASTERY_LEARN
public class SERVER_SKILL_MASTERY_LEARN_RESPONSE : Packet
{
    public uint MasteryId;
    public byte NewLevel;
    public byte Result;

    public SERVER_SKILL_MASTERY_LEARN_RESPONSE() : base(0xB0A2)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x01)
        {
            TryRead(out MasteryId);
            TryRead(out NewLevel);
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        if (Result == 0x01)
        {
            TryWrite(MasteryId);
            TryWrite(NewLevel);
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_SKILL_MASTERY_LEARN_RESPONSE();
    }
}