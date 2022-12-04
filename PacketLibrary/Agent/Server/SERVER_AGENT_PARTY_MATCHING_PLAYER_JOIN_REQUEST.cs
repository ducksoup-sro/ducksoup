using API;
using PacketLibrary.Enums;
using PacketLibrary.Objects.Agent;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_PLAYER_JOIN
public class SERVER_AGENT_PARTY_MATCHING_PLAYER_JOIN_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x706D;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public uint RequestID;
    public uint UserJID;
    public uint MatchingID;
    public uint PrimaryMastery;
    public uint SecondaryMastery;
    public Job JobState;
    public PartyMemberInfo MemberInfo;

    public Task Read(Packet packet)
    {
        RequestID = packet.ReadUInt32(); // 4   uint            RequestID
        UserJID = packet.ReadUInt32(); // 4   uint            UserJID
        MatchingID = packet.ReadUInt32(); // 4   uint            Party.MatchingID
        PrimaryMastery = packet.ReadUInt32(); // 4   uint            PrimaryMastery
        SecondaryMastery = packet.ReadUInt32(); // 4   uint            SecondaryMastery
        JobState = (Job) packet.ReadUInt8(); // 1   byte            JobState
        MemberInfo = new PartyMemberInfo(packet); // *   PartyMemberInfo memberInfo
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(RequestID);
        response.WriteUInt32(UserJID);
        response.WriteUInt32(MatchingID);
        response.WriteUInt32(PrimaryMastery);
        response.WriteUInt32(SecondaryMastery);
        response.WriteUInt8(JobState);
        response = MemberInfo.Build(response);
        return response;
    }

    public static Packet of(uint requestID, uint userJID, uint matchingID, uint primaryMastery, uint secondaryMastery,
        Job jobState, PartyMemberInfo memberInfo)
    {
        return new SERVER_AGENT_PARTY_MATCHING_PLAYER_JOIN_REQUEST
        {
            RequestID = requestID,
            UserJID = userJID,
            MatchingID = matchingID,
            PrimaryMastery = primaryMastery,
            SecondaryMastery = secondaryMastery,
            JobState = jobState,
            MemberInfo = memberInfo
        }.Build();
    }
}