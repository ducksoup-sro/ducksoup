using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_JOIN
public class SERVER_PARTY_MATCHING_JOIN_RESPONSE : Packet
{
    public PartyErrorCode ErrorCode;
    public PartyMatchingJoinResult JoinResult;
    public byte Result;

    public SERVER_PARTY_MATCHING_JOIN_RESPONSE() : base(0xB06D)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead<byte>(out Result);
        switch (Result)
        {
            case 0x01:
                TryRead<PartyMatchingJoinResult>(out JoinResult);
                break;
            case 0x02:
                TryRead<PartyErrorCode>(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        switch (Result)
        {
            case 0x01:
                TryWrite<ushort>((ushort)JoinResult);
                break;
            case 0x02:
                TryWrite<ushort>((ushort)ErrorCode);
                break;
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_JOIN_RESPONSE();
    }
}