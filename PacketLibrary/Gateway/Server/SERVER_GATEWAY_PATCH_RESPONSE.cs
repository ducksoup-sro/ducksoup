using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

public class SERVER_GATEWAY_PATCH_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA100;
    public static bool Encrypted => false;
    public static bool Massive => true;
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

    public static async Task<Packet> of()
    {
        throw new NotImplementedException();
    }
}

