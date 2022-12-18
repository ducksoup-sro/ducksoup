using API;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

public class SERVER_AGENT_ENTITY_GROUPSPAWN_BEGIN : IPacketStructure
{
    public static ushort MsgId => 0x3017;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public SpawnInfoType SpawnInfoType { get; set; }
    public ushort Amount { get; set; }
    
    public Task Read(Packet packet)
    {
        SpawnInfoType = (SpawnInfoType) packet.ReadUInt8();
        Amount = packet.ReadUInt16();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(SpawnInfoType);
        response.WriteUInt16(Amount);
        return response;
    }

    public static Packet of(SpawnInfoType spawnInfoType, ushort amount)
    {
        return new SERVER_AGENT_ENTITY_GROUPSPAWN_BEGIN
        {
            SpawnInfoType = spawnInfoType,
            Amount = amount
        }.Build();
    }
}

