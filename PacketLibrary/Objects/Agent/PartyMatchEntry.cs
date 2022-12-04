using API;
using API.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Agent;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMatchEntry
{
    public uint Number;
    public uint MasterJID;
    public string MasterName;
    public byte CountryType;
    public byte MemberCount;
    public PartyEnums.PartySettingsFlag PartySettingsFlag;
    public PartyEnums.PartyPurposeType PurposeType;
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
        Number = packet.ReadUInt32(); // 4   uint    PartyMatch.Number
        MasterJID = packet.ReadUInt32(); // 4   uint    PartyMatch.MasterJID
        MasterName = packet.ReadAscii(); // 2   ushort    PartyMatch.MasterName.Length
        //     *   string    PartyMatch.MasterName
        CountryType = packet.ReadUInt8(); // 1   byte    PartyMatch.CountryType
        MemberCount = packet.ReadUInt8(); // 1   byte    PartyMatch.MemberCount
        PartySettingsFlag = (PartyEnums.PartySettingsFlag) packet.ReadUInt8(); // 1   byte    PartyMatch.PartySettingsFlag
        PurposeType = (PartyEnums.PartyPurposeType) packet.ReadUInt8(); // 1   byte    PartyMatch.PurposeType
        LevelMin = packet.ReadUInt8(); // 1   byte    PartyMatch.LevelMin
        LevelMax = packet.ReadUInt8(); // 1   byte    PartyMatch.LevelMax
        Title = packet.ReadAscii(); // 2   ushort    PartyMatch.Title.Length
        //     *   string    PartyMatch.Title

        return Task.CompletedTask;
    }

    public Packet Build(Packet response)
    {
        response.WriteUInt32(Number);
        response.WriteUInt32(MasterJID);
        response.WriteAscii(MasterName);
        response.WriteUInt8(CountryType);
        response.WriteUInt8(MemberCount);
        response.WriteUInt8(PartySettingsFlag);
        response.WriteUInt8(PurposeType);
        response.WriteUInt8(LevelMin);
        response.WriteUInt8(LevelMax);
        response.WriteAscii(Title);
        return response;
    }
}