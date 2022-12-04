using API;
using API.Enums;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_FORM
public class CLIENT_AGENT_PARTY_MATCHING_FORM_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7069;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint MatchingID;
    public uint ID;
    public PartyEnums.PartySettingsFlag SettingsFlag;
    public PartyEnums.PartyPurposeType Purpose;
    public byte LevelRangeMin;
    public byte LevelRangeMax;
    public string Title;

    public Task Read(Packet packet)
    {
        MatchingID = packet.ReadUInt32(); // 4   uint    Party.MatchingID    // 0
        ID = packet.ReadUInt32(); // 4   uint    Party.ID            // 0 if forming solo
        SettingsFlag = (PartyEnums.PartySettingsFlag) packet.ReadUInt8(); // 1   byte    Party.SettingsFlag
        Purpose = (PartyEnums.PartyPurposeType) packet.ReadUInt8(); // 1   byte    Party.Purpose
        LevelRangeMin = packet.ReadUInt8(); // 1   byte    Party.LevelRangeMin
        LevelRangeMax = packet.ReadUInt8(); // 1   byte    Party.LevelRangeMax
        Title = packet.ReadAscii(); // 2   ushort  Party.Title.Length
        //     *   string  Party.Title
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(MatchingID);
        response.WriteUInt32(ID);
        response.WriteUInt8(SettingsFlag);
        response.WriteUInt8(Purpose);
        response.WriteUInt8(LevelRangeMin);
        response.WriteUInt8(LevelRangeMax);
        response.WriteAscii(Title);
        return response;
    }

    public static Packet of(uint matchingID, uint id, PartyEnums.PartySettingsFlag settingsFlag,
        PartyEnums.PartyPurposeType purpose, byte levelRangeMin, byte levelRangeMax, string title)
    {
        return new CLIENT_AGENT_PARTY_MATCHING_FORM_REQUEST
        {
            MatchingID = matchingID,
            ID = id,
            SettingsFlag = settingsFlag,
            Purpose = purpose,
            LevelRangeMin = levelRangeMin,
            LevelRangeMax = levelRangeMax,
            Title = title
        }.Build();
    }
}