using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_DELETE
public class CLIENT_PARTY_MATCHING_DELETE_REQUEST : Packet
{
    public uint MatchingId;

    public CLIENT_PARTY_MATCHING_DELETE_REQUEST() : base(0x706B)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out MatchingId);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(MatchingId);
        return this;
    }

    public static Task<Packet> of(uint matchingId)
    {
        return new CLIENT_PARTY_MATCHING_DELETE_REQUEST
        {
            MatchingId = matchingId
        }.Build();
    }
}