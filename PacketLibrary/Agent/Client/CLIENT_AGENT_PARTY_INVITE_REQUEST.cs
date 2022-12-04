using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_INVITE
public class CLIENT_AGENT_PARTY_INVITE_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7062;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint GID;
    
    public Task Read(Packet packet)
    {
        GID = packet.ReadUInt32(); // 4   uint    GID // of player to be invited
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(GID);
        return response;
    }

    public static Packet of(uint gid)
    {
        return new CLIENT_AGENT_PARTY_INVITE_REQUEST
        {
            GID = gid
        }.Build();
    }
}

