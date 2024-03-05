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
        TryRead<uint>(out MatchingId);
        TryRead<uint>(out Id);
        TryRead<PartySettingsFlag>(out SettingsFlag);
        TryRead<PartyPurposeType>(out Purpose);
        TryRead<byte>(out LevelRangeMin);
        TryRead<byte>(out LevelRangeMax);
        TryRead(out Title);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<uint>(MatchingId);
        TryWrite<uint>(Id);
        TryWrite<byte>((byte)SettingsFlag);
        TryWrite<byte>((byte)Purpose);
        TryWrite<byte>(LevelRangeMin);
        TryWrite<byte>(LevelRangeMax);
        TryWrite(Title);
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_PARTY_MATCHING_CHANGE_REQUEST();
    }
}