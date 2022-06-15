using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#request
public class CLIENT_GATEWAY_SHARD_LIST_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6101;
    public static bool Encrypted => true;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    //Empty
    
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
        return new CLIENT_GATEWAY_SHARD_LIST_REQUEST().Build();
    }
}

