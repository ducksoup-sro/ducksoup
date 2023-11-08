using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Party;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMatchEntry
{
    public uint Number;
    public uint MasterJID;
    public string MasterName;
    public byte CountryType;
    public byte MemberCount;
    public PartySettingsFlag PartySettingsFlag;
    public PartyPurposeType PurposeType;
    public byte LevelMin;
    public byte LevelMax;
    public string Title;

    public PartyMatchEntry()
    {
    }

    public PartyMatchEntry(Packet packet)
    {
        Read(packet);
    }

    public Task Read(Packet packet)
    {
        packet.TryRead(out Number)
            .TryRead(out MasterJID)
            .TryRead(out MasterName)
            .TryRead(out CountryType)
            .TryRead(out MemberCount)
            .TryRead(out PartySettingsFlag)
            .TryRead(out PurposeType)
            .TryRead(out LevelMin)
            .TryRead(out LevelMax)
            .TryRead(out Title);
        return Task.CompletedTask;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Number)
            .TryWrite(MasterJID)
            .TryWrite(MasterName)
            .TryWrite(CountryType)
            .TryWrite(MemberCount)
            .TryWrite(PartySettingsFlag)
            .TryWrite(PurposeType)
            .TryWrite(LevelMin)
            .TryWrite(LevelMax)
            .TryWrite(Title);
        return packet;
    }
}