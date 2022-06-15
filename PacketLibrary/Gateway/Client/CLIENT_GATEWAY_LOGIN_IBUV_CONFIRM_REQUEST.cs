using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Client;

public class CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6323;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public Task Read(Packet packet)
    {
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        return response;    
    }

    public static Packet of()
    {
        return new CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST().Build();
    }
}

