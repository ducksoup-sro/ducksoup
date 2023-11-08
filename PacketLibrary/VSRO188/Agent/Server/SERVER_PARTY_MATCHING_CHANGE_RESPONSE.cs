using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_CHANGE
public class SERVER_PARTY_MATCHING_CHANGE_RESPONSE : Packet
{
    public byte Result;
    public uint MatchingId;
    public uint Id;
    public PartySettingsFlag partySetting;
    public PartyPurposeType partyPurpose;
    public byte LevelRangeMin;
    public byte LevelRangeMax;
    public string Title;
    public PartyErrorCode errorCode;
    
    public SERVER_PARTY_MATCHING_CHANGE_RESPONSE() : base(0xB06A)
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
                TryRead(out Id);
                TryRead(out partySetting);
                TryRead(out partyPurpose);
                TryRead(out LevelRangeMin);
                TryRead(out LevelRangeMax);
                TryRead(out Title);
                break;
            case 0x02:
                TryRead(out errorCode);
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
                TryWrite(Id);
                TryWrite(partySetting);
                TryWrite(partyPurpose);
                TryWrite(LevelRangeMin);
                TryWrite(LevelRangeMax);
                TryWrite(Title);
                break;
            case 0x02:
                TryWrite(errorCode);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_CHANGE_RESPONSE();
    }
}