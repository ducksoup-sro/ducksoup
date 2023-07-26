using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0x600D%20-%20SERVER_GLOBAL_MASSIVE.cs
public class SERVER_GLOBAL_MASSIVE_MESSAGE : Packet
{
    public SERVER_GLOBAL_MASSIVE_MESSAGE() : base(0x600D)
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