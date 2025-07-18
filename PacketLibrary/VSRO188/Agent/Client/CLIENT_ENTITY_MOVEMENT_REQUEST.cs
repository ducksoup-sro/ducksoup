using PacketLibrary.VSRO188.Agent.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ENTITY_MOVEMENT
public class CLIENT_ENTITY_MOVEMENT_REQUEST : Packet
{
    public byte ClickType; // 0 = sky/keys, 1 = ground
    public Position Position;
    public byte Unk1;
    public short Unk2;

    public CLIENT_ENTITY_MOVEMENT_REQUEST() : base(0x7021)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead<byte>(out ClickType);
        switch (ClickType)
        {
            case 0:
                TryRead<byte>(out Unk1);
                TryRead<short>(out Unk2);
                break;
            case 1:
                Position = Position.FromPacketConditional(this, false);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>(ClickType);
        switch (ClickType)
        {
            case 0:
                TryWrite<byte>(Unk1);
                TryWrite<short>(Unk2);
                break;
            case 1:
                Position.ToPacketConditional(this, false);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_ENTITY_MOVEMENT_REQUEST();
    }
}