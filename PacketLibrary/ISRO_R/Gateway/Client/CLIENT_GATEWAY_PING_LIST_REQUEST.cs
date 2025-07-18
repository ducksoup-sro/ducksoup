using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Client;

public class CLIENT_GATEWAY_PING_LIST_REQUEST : Packet
{
    public CLIENT_GATEWAY_PING_LIST_REQUEST() : base(0x6107, true)
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
        return this;
    }
}