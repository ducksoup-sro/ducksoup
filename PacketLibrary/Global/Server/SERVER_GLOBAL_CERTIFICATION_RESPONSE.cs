using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Global.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/blob/master/Packets/GLOBAL/0xA003%20-%20SERVER_GLOBAL_CERTIFICATION_RESPONSE.cs
public class SERVER_GLOBAL_CERTIFICATION_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA003;
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

    public static async Task<Packet> of()
    {
        throw new NotImplementedException();
    }
}

