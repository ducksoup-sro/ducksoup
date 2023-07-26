using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0xA003%20-%20SERVER_GLOBAL_CERTIFICATION_RESPONSE.cs
public class SERVER_GLOBAL_CERTIFICATION_RESPONSE : Packet
{
    public SERVER_GLOBAL_CERTIFICATION_RESPONSE() : base(0xA003)
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