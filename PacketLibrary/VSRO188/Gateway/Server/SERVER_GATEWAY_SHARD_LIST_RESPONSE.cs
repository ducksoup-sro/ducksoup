using PacketLibrary.VSRO188.Gateway.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#response
public class SERVER_GATEWAY_SHARD_LIST_RESPONSE : Packet
{
    public List<Farm> Farms = new List<Farm>();
    public List<Shard> Shards = new List<Shard>();

    public SERVER_GATEWAY_SHARD_LIST_RESPONSE() : base(0xA101)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        while (true)
        {
            TryRead<bool>(out bool hasEntries); // 1   bool    hasEntries
            if (!hasEntries)
                break;
            Farms.Add(new Farm(this));
        }

        while (true)
        {
            TryRead<bool>(out bool hasEntries); // 1   bool    hasEntries
            if (!hasEntries)
                break;
            Shards.Add(new Shard(this));
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();

        foreach (Farm farm in Farms)
        {
            TryWrite(true);
            farm.Build(this);
        }

        TryWrite(false);
        foreach (Shard shard in Shards)
        {
            TryWrite(true);
            shard.Build(this);
        }

        TryWrite(false);

        return this;
    }

    public static SERVER_GATEWAY_SHARD_LIST_RESPONSE of(List<Farm> farms, List<Shard> shards)
    {
        return new SERVER_GATEWAY_SHARD_LIST_RESPONSE
        {
            Farms = farms,
            Shards = shards
        };
    }
}