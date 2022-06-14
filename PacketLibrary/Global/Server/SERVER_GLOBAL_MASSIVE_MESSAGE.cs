using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Global.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0x600D%20-%20SERVER_GLOBAL_MASSIVE.cs
public class SERVER_GLOBAL_MASSIVE_MESSAGE : IPacketStructure
{
    public static ushort MsgId => 0x600D;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public Task Read(Packet packet)
    {
        throw new NotImplementedException();
    }

    public Packet Build()
    {
        throw new NotImplementedException();
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}

