using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_SHARD_LIST_RESPONSE : Packet
{
    public SERVER_GATEWAY_SHARD_LIST_RESPONSE() : base(0xA101)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
    }

    public override async Task<Packet> Build()
    {
        return this;
    }
}