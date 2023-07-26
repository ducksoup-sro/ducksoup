using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Server;

public class SERVER_GLOBAL_HANDSHAKE_SETUP_CHALLENGE : Packet
{
    public SERVER_GLOBAL_HANDSHAKE_SETUP_CHALLENGE() : base(0x5000)
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