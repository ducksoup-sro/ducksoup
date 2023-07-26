using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Client;

public class CLIENT_GLOBAL_HANDSHAKE_ACCEPT : Packet
{
    public CLIENT_GLOBAL_HANDSHAKE_ACCEPT() : base(0x9000)
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