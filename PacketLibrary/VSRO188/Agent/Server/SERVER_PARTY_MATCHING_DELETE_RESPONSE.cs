using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_DELETE
public class SERVER_PARTY_MATCHING_DELETE_RESPONSE : Packet
{
    public PartyErrorCode ErrorCode;
    public uint MatchingId;
    public byte Result;

    public SERVER_PARTY_MATCHING_DELETE_RESPONSE() : base(0xB06B)
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
                TryRead<uint>(out MatchingId);
                break;
            case 0x02:
                TryRead<PartyErrorCode>(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>(Result);
        switch (Result)
        {
            case 0x01:
                TryWrite<uint>(MatchingId);
                break;
            case 0x02:
                TryWrite<ushort>((ushort)ErrorCode);
                break;
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_DELETE_RESPONSE();
    }
}