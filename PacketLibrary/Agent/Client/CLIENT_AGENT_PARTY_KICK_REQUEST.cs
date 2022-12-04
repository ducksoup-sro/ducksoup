using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_KICK
public class CLIENT_AGENT_PARTY_KICK_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7063;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint JID;
    
    public Task Read(Packet packet)
    {
        JID = packet.ReadUInt32(); // 4   uint    memberInfo.JID
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(JID);
        return response;
    }

    public static Packet of(uint jid)
    {
        return new CLIENT_AGENT_PARTY_KICK_REQUEST
        {
            JID = jid
        }.Build();
    }
}

