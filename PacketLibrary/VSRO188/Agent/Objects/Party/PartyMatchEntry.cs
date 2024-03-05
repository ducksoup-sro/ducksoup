using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Party;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMatchEntry
{
    public byte CountryType;
    public byte LevelMax;
    public byte LevelMin;
    public uint MasterJID;
    public string MasterName;
    public byte MemberCount;
    public uint Number;
    public PartySettingsFlag PartySettingsFlag;
    public PartyPurposeType PurposeType;
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
        packet.TryRead<uint>(out Number)
            .TryRead<uint>(out MasterJID)
            .TryRead(out MasterName)
            .TryRead<byte>(out CountryType)
            .TryRead<byte>(out MemberCount)
            .TryRead<PartySettingsFlag>(out PartySettingsFlag)
            .TryRead<PartyPurposeType>(out PurposeType)
            .TryRead<byte>(out LevelMin)
            .TryRead<byte>(out LevelMax)
            .TryRead(out Title);
        return Task.CompletedTask;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite<uint>(Number)
            .TryWrite<uint>(MasterJID)
            .TryWrite(MasterName)
            .TryWrite<byte>(CountryType)
            .TryWrite<byte>(MemberCount)
            .TryWrite<byte>((byte)PartySettingsFlag)
            .TryWrite<byte>((byte)PurposeType)
            .TryWrite<byte>(LevelMin)
            .TryWrite<byte>(LevelMax)
            .TryWrite(Title);
        return packet;
    }
}