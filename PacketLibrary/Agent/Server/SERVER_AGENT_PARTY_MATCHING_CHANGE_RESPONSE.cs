using API.Enums;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_CHANGE
public class SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB06A;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public uint MatchingID;
    public uint ID;
    public PartyEnums.PartySettingsFlag SettingsFlag;
    public PartyEnums.PartyPurposeType Purpose;
    public byte LevelRangeMin;
    public byte LevelRangeMax;
    public string Title;
    public ushort ErrorCode;
    
public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        switch (Result)
        {
            case 1:
                MatchingID = packet.ReadUInt32(); // 4   uint    Party.MatchingID    // 0
                ID = packet.ReadUInt32(); // 4   uint    Party.ID            // 0 if forming solo
                SettingsFlag = (PartyEnums.PartySettingsFlag) packet.ReadUInt8(); // 1   byte    Party.SettingsFlag
                Purpose = (PartyEnums.PartyPurposeType) packet.ReadUInt8(); // 1   byte    Party.Purpose
                LevelRangeMin = packet.ReadUInt8(); // 1   byte    Party.LevelRangeMin
                LevelRangeMax = packet.ReadUInt8(); // 1   byte    Party.LevelRangeMax
                Title = packet.ReadAscii(); // 2   ushort  Party.Title.Length
                //     *   string  Party.Title
                break;
            case 2:
                ErrorCode = packet.ReadUInt16();  // 2	ushort	errorCode
                break;
        }
        
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        switch (Result)
        {
            case 1:
                response.WriteUInt32(MatchingID);
                response.WriteUInt32(ID);
                response.WriteUInt8(SettingsFlag);
                response.WriteUInt8(Purpose);
                response.WriteUInt8(LevelRangeMin);
                response.WriteUInt8(LevelRangeMax);
                response.WriteAscii(Title);
                break;
            case 2:
                response.WriteUInt16(ErrorCode);
                break;
        }

        return response;
    }

    public static Packet of(uint matchingID, uint id, PartyEnums.PartySettingsFlag settingsFlag,
        PartyEnums.PartyPurposeType purpose, byte levelRangeMin, byte levelRangeMax, string title)
    {
        return new SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE
        {
            Result = 1,
            MatchingID = matchingID,
            ID = id,
            SettingsFlag = settingsFlag,
            Purpose = purpose,
            LevelRangeMin = levelRangeMin,
            LevelRangeMax = levelRangeMax,
            Title = title
        }.Build();
    }
    
    public static Packet of(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_MATCHING_CHANGE_RESPONSE
        {
            Result = 1,
            ErrorCode = errorCode
        }.Build();
    }
}

