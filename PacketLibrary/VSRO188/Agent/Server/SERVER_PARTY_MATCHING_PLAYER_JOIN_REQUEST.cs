using PacketLibrary.VSRO188.Agent.Objects.Party;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_PLAYER_JOIN
public class SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST : Packet
{
    public byte JobState;
    public uint MatchingID;
    public PartyMemberInfo memberInfo;
    public uint PrimaryMastery;
    public uint RequestID;
    public uint SecondaryMastery;
    public uint UserJID;

    public SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST() : base(0x706D)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead<uint>(out RequestID);
        TryRead<uint>(out UserJID);
        TryRead<uint>(out MatchingID);
        TryRead<uint>(out PrimaryMastery);
        TryRead<uint>(out SecondaryMastery);
        TryRead<byte>(out JobState);
        var memberInfo = new PartyMemberInfo(this);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<uint>(RequestID);
        TryWrite<uint>(UserJID);
        TryWrite<uint>(MatchingID);
        TryWrite<uint>(PrimaryMastery);
        TryWrite<uint>(SecondaryMastery);
        TryWrite<byte>(JobState);
        memberInfo.Build(this);
        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST();
    }
}