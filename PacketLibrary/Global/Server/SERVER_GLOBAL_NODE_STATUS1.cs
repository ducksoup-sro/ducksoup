using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Server;

public class SERVER_GLOBAL_NODE_STATUS1 : Packet
{
    public SERVER_GLOBAL_NODE_STATUS1() : base(0x2005, false, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        throw new NotImplementedException();
    }

    public override async Task<Packet> Build()
    {
        throw new NotImplementedException();
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}