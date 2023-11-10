using PacketLibrary.VSRO188.Agent.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ENTITY_MOVEMENT
public class CLIENT_ENTITY_MOVEMENT_REQUEST : Packet
{
    public byte UnkByte0;
    public Position Position;
    
    public CLIENT_ENTITY_MOVEMENT_REQUEST() : base(0x7021)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out UnkByte0);
        Position = Position.FromPacketConditional(this, false);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(UnkByte0);
        Position.ToPacketConditional(this, false);
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_ENTITY_MOVEMENT_REQUEST();
    }
}