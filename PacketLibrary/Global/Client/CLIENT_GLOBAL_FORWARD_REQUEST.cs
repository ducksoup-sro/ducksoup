using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Global.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0x6008%20-%20CLIENT_GLOBAL_FORWARD_REQUEST.cs
public class CLIENT_GLOBAL_FORWARD_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6008;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public Task Read(Packet packet)
    {
        throw new NotImplementedException();
    }

    public Packet Build()
    {
        throw new NotImplementedException();
    }

    public static async Task<Packet> of()
    {
        throw new NotImplementedException();
    }
}

