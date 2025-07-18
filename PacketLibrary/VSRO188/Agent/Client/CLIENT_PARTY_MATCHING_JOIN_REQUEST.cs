using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_PLAYER_JOIN
public class CLIENT_PARTY_MATCHING_JOIN_REQUEST : Packet
{
    public uint MatchingId;

    public CLIENT_PARTY_MATCHING_JOIN_REQUEST() : base(0x706D)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead<uint>(out MatchingId);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<uint>(MatchingId);
        return this;
    }

    public static Task<Packet> of(uint matchingId)
    {
        return new CLIENT_PARTY_MATCHING_JOIN_REQUEST
        {
            MatchingId = matchingId
        }.Build();
    }
}