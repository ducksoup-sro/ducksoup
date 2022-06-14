using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT_CANCEL
public class CLIENT_AGENT_LOGOUT_CANCEL_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7006;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

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
        return new CLIENT_AGENT_LOGOUT_CANCEL_REQUEST().Build();
    }
}