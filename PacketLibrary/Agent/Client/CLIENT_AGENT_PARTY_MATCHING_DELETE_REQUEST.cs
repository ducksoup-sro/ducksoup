using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_DELETE
public class CLIENT_AGENT_PARTY_MATCHING_DELETE_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x706B;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint MatchingID;
    
    public Task Read(Packet packet)
    {
        MatchingID = packet.ReadUInt32(); // 4   uint    Party.MatchingID
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(MatchingID);
        return response;
    }

    public static Packet of(uint matchingId)
    {
        return new CLIENT_AGENT_PARTY_MATCHING_DELETE_REQUEST
        {
            MatchingID = matchingId
        }.Build();
    }
}

