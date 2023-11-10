using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ALCHEMY_DISMANTLE
public class CLIENT_ALCHEMY_DISMANTLE_REQUEST : Packet
{
    public byte SlotCount;
    public byte[] Slots;
    
    public CLIENT_ALCHEMY_DISMANTLE_REQUEST() : base(0x7157)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out SlotCount);
        for (var i = 0; i < SlotCount; i++)
        {
            TryRead(out Slots[i]);
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(SlotCount);
        for (var i = 0; i < SlotCount; i++)
        {
            TryWrite(Slots[i]);
        }
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_ALCHEMY_DISMANTLE_REQUEST();
    }
}