using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_SKILL_MASTERY_LEARN
public class CLIENT_SKILL_MASTERY_LEARN_REQUEST : Packet
{
    public uint MasteryId;
    public byte Amount; // // 1 = Normal behavior since client/server is designed to level up one by one (0 = will not use SP)
    public CLIENT_SKILL_MASTERY_LEARN_REQUEST() : base(0x70A2)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out MasteryId);
        TryRead(out Amount);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(MasteryId);
        TryWrite(Amount);
        return this;
    }

    public static Task<Packet> of(uint MasteryId)
    {
        return new CLIENT_SKILL_MASTERY_LEARN_REQUEST
        {
            MasteryId = MasteryId,
            Amount = 0x01
        }.Build();
    }
}