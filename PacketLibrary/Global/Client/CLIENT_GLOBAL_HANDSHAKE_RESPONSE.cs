using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Global.Client;

public class CLIENT_GLOBAL_HANDSHAKE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0x5000;
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

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}

