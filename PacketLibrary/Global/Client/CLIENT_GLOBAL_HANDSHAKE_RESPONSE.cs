using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Client;

public class CLIENT_GLOBAL_HANDSHAKE_RESPONSE : Packet
{
    public CLIENT_GLOBAL_HANDSHAKE_RESPONSE() : base(0x5000)
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