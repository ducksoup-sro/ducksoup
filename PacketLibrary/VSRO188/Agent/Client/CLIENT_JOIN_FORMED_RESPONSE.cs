using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_PLAYER_JOIN
public class CLIENT_JOIN_FORMED_RESPONSE : Packet
{
    public uint RequestId;
    public uint UserJid;
    public PartyMatchingJoinResult RequestResponse;

    public CLIENT_JOIN_FORMED_RESPONSE() : base(0x306E)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out RequestId);
        TryRead(out UserJid);
        TryRead(out RequestResponse);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(RequestId);
        TryWrite(UserJid);
        TryWrite(RequestResponse);
        return this;
    }

    public static Task<Packet> of(uint requestId, uint userJid, PartyMatchingJoinResult requestResponse)
    {
        return new CLIENT_JOIN_FORMED_RESPONSE
        {
            RequestId = requestId,
            UserJid = userJid,
            RequestResponse = requestResponse
        }.Build();
    }
}