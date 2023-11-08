using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_DELETE
public class SERVER_PARTY_MATCHING_DELETE_RESPONSE : Packet
{
    public byte Result;
    public uint MatchingId;
    public PartyErrorCode ErrorCode;
    
    public SERVER_PARTY_MATCHING_DELETE_RESPONSE() : base(0xB06B)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out Result);
        switch (Result)
        {
            case 0x01:
                TryRead(out MatchingId);
                break;
            case 0x02:
                TryRead(out ErrorCode);
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
                TryWrite(MatchingId);
                break;
            case 0x02:
                TryWrite(ErrorCode);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_DELETE_RESPONSE();
    }
}