using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Client;

public class CLIENT_GATEWAY_PING_LIST_REQUEST : Packet
{
    public CLIENT_GATEWAY_PING_LIST_REQUEST() : base(0x6107, true, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;
    
    public async override Task Read()
    {
        // Empty
    }

    public async override Task<Packet> Build()
    {
        return this;
    }
}