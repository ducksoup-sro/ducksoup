using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_ENTITY_GROUPSPAWN_BEGIN : Packet
{
    public SERVER_ENTITY_GROUPSPAWN_BEGIN() : base(0x3017, false, false)
    {
    }
    
    public SERVER_ENTITY_GROUPSPAWN_BEGIN(Packet packet) : base(packet)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public SpawnInfoType SpawnInfoType;
    public ushort Amount;

    public override async Task Read()
    {
        TryRead<SpawnInfoType>(out SpawnInfoType);
        TryRead<ushort>(out Amount);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<SpawnInfoType>(SpawnInfoType);
        TryRead<ushort>(out Amount);

        return this;
    }

    public static Packet of(SpawnInfoType spawnInfoType, ushort amount)
    {
        return new SERVER_ENTITY_GROUPSPAWN_BEGIN
        {
            SpawnInfoType = spawnInfoType,
            Amount = amount
        };
    }
}