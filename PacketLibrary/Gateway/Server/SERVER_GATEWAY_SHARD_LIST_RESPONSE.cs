using PacketLibrary.Enums;
using PacketLibrary.Objects.Gateway;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#response
public class SERVER_GATEWAY_SHARD_LIST_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA101;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public List<Farm> Farms = new();
    public List<Shard> Shards = new();

    public Task Read(Packet packet)
    {
        //Farm
        while (true)
        {
            var hasEntries = packet.ReadBool(); // 1   bool    hasEntries
            if (!hasEntries)
                break;
            Farms.Add(new Farm(packet));
        }

        //Shards
        while (true)
        {
            var hasEntries = packet.ReadBool(); // 1   bool    hasEntries
            if (!hasEntries)
                break;
            Shards.Add(new Shard(packet));
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        foreach (var farm in Farms)
        {
            response.WriteBool(true);
            farm.build(response);
        }

        response.WriteBool(false);
        foreach (var shard in Shards)
        {
            response.WriteBool(true);
            shard.build(response);
        }

        response.WriteBool(false);

        return response;
    }

    public static Packet of(List<Farm> farms, List<Shard> shards)
    {
        return new SERVER_GATEWAY_SHARD_LIST_RESPONSE()
        {
            Farms = farms,
            Shards = shards
        }.Build();
    }
}