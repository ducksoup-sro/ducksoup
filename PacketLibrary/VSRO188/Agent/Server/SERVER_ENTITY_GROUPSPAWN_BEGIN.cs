using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://www.elitepvpers.com/forum/sro-coding-corner/3970615-release-characterdata-entityspawn.html
public class SERVER_ENTITY_GROUPSPAWN_BEGIN : Packet
{
    public SpawnInfoType SpawnInfoType;
    public ushort Amount;

    public SERVER_ENTITY_GROUPSPAWN_BEGIN() : base(0x3017)
    {
    }

    public SERVER_ENTITY_GROUPSPAWN_BEGIN(Packet packet) : base(packet)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out SpawnInfoType);
        TryRead(out Amount);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(SpawnInfoType);
        TryWrite(Amount);
        return this;
    }

    public static SERVER_ENTITY_GROUPSPAWN_BEGIN of(SpawnInfoType spawnInfoType, ushort amount)
    {
        return new SERVER_ENTITY_GROUPSPAWN_BEGIN
        {
            SpawnInfoType = spawnInfoType,
            Amount = amount
        };
    }
}