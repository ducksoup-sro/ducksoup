using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0x6003%20-%20CLIENT_GLOBAL_CERTIFICATION_REQUEST.cs
public class CLIENT_GLOBAL_CERTIFICATION_REQUEST : Packet
{
    public CLIENT_GLOBAL_CERTIFICATION_REQUEST() : base(0x6003)
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