using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGUT_SUCCESS
public class SERVER_AGENT_LOGOUT_SUCCESS : IPacketStructure
{
    public static ushort MsgId => 0x300a;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;
    
    // empty

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
        return new SERVER_AGENT_LOGOUT_SUCCESS().Build();
    }
}

