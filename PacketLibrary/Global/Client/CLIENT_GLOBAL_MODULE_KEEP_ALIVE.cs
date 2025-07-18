using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/Global-packets
public class CLIENT_GLOBAL_MODULE_KEEP_ALIVE : Packet
{
    public CLIENT_GLOBAL_MODULE_KEEP_ALIVE() : base(0x2002)
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
        // Empty
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_GLOBAL_MODULE_KEEP_ALIVE();
    }
}