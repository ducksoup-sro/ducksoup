using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_CHANGE
public class CLIENT_PARTY_MATCHING_CHANGE_REQUEST : Packet
{
    public uint Id;
    public byte LevelRangeMax;
    public byte LevelRangeMin;
    public uint MatchingId;
    public PartyPurposeType Purpose;
    public PartySettingsFlag SettingsFlag;
    public string Title;

    public CLIENT_PARTY_MATCHING_CHANGE_REQUEST() : base(0x706A)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out MatchingId);
        TryRead(out Id);
        TryRead(out SettingsFlag);
        TryRead(out Purpose);
        TryRead(out LevelRangeMin);
        TryRead(out LevelRangeMax);
        TryRead(out Title);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(MatchingId);
        TryWrite(Id);
        TryWrite(SettingsFlag);
        TryWrite(Purpose);
        TryWrite(LevelRangeMin);
        TryWrite(LevelRangeMax);
        TryWrite(Title);
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_PARTY_MATCHING_CHANGE_REQUEST();
    }
}