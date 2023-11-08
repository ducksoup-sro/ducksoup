using PacketLibrary.VSRO188.Agent.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_ENTITY_POSITION_UPDATE : Packet
{
    public Position Position;
    public uint EntityId;
    
    public SERVER_ENTITY_POSITION_UPDATE() : base(0x3028)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        Position = Position.FromPacket(this);
        TryRead(out EntityId);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        Position.ToPacket(this);
        TryWrite(EntityId);
        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_ENTITY_POSITION_UPDATE
                { }
            .Build();
    }
}