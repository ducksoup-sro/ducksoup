using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#request
public class CLIENT_GATEWAY_SHARD_LIST_REQUEST : Packet
{
    //Empty

    public CLIENT_GATEWAY_SHARD_LIST_REQUEST() : base(0x6101, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        // Empty
    }

    public override async Task<Packet> Build()
    {
        Reset();
        // Empty
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_GATEWAY_SHARD_LIST_REQUEST();
    }
}