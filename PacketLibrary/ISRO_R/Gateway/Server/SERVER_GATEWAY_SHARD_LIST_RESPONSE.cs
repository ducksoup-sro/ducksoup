using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_SHARD_LIST_RESPONSE : Packet
{
    public SERVER_GATEWAY_SHARD_LIST_RESPONSE() : base(0xA101, false, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;
    
    public async override Task Read()
    {

    }

    public async override Task<Packet> Build()
    {
        return this;
    }
}