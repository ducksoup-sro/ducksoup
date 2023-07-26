using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#ping-request
public class CLIENT_GATEWAY_SHARD_LIST_PING_REQUEST : Packet
{
    //Empty

    public CLIENT_GATEWAY_SHARD_LIST_PING_REQUEST() : base(0x6106)
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
        return new CLIENT_GATEWAY_SHARD_LIST_PING_REQUEST();
    }
}