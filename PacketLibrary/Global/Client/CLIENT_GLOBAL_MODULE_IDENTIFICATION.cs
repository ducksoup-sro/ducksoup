using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Client;

public class CLIENT_GLOBAL_MODULE_IDENTIFICATION : Packet
{
    public CLIENT_GLOBAL_MODULE_IDENTIFICATION() : base(0x2001, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

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