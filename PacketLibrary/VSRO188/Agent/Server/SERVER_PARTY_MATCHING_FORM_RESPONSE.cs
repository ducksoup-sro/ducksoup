using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_FORM
public class SERVER_PARTY_MATCHING_FORM_RESPONSE : Packet
{
    public PartyErrorCode errorCode;
    public uint Id;
    public byte LevelRangeMax;
    public byte LevelRangeMin;
    public uint MatchingId;
    public PartyPurposeType partyPurpose;
    public PartySettingsFlag partySetting;
    public byte Result;
    public string Title;

    public SERVER_PARTY_MATCHING_FORM_RESPONSE() : base(0xB069)
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
                TryRead<uint>(out MatchingId);
                TryRead<uint>(out Id);
                TryRead<PartySettingsFlag>(out partySetting);
                TryRead<PartyPurposeType>(out partyPurpose);
                TryRead<byte>(out LevelRangeMin);
                TryRead<byte>(out LevelRangeMax);
                TryRead(out Title);
                break;
            case 0x02:
                TryRead<PartyErrorCode>(out errorCode);
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
                TryWrite<uint>(MatchingId);
                TryWrite<uint>(Id);
                TryWrite<byte>((byte) partySetting);
                TryWrite<byte>((byte) partyPurpose);
                TryWrite<byte>(LevelRangeMin);
                TryWrite<byte>(LevelRangeMax);
                TryWrite(Title);
                break;
            case 0x02:
                TryWrite<ushort>((ushort)errorCode);
                break;
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_FORM_RESPONSE();
    }
}