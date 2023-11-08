using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_FORM
public class CLIENT_PARTY_MATCHING_FORM_REQUEST : Packet
{
    public uint Id;
    public byte LevelRangeMax;
    public byte LevelRangeMin;
    public uint MatchingId;
    public PartyPurposeType partyPurpose;
    public PartySettingsFlag partySetting;
    public string Title;

    public CLIENT_PARTY_MATCHING_FORM_REQUEST() : base(0x7069)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out MatchingId);
        TryRead(out Id);
        TryRead(out partySetting);
        TryRead(out partyPurpose);
        TryRead(out LevelRangeMin);
        TryRead(out LevelRangeMax);
        TryRead(out Title);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(MatchingId);
        TryWrite(Id);
        TryWrite(partySetting);
        TryWrite(partyPurpose);
        TryWrite(LevelRangeMin);
        TryWrite(LevelRangeMax);
        TryWrite(Title);
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_PARTY_MATCHING_FORM_REQUEST();
    }
}