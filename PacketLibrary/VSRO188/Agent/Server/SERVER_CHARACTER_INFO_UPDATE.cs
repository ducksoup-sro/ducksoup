using PacketLibrary.VSRO188.Agent.Enums.Character;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_INFO_UPDATE
public class SERVER_CHARACTER_INFO_UPDATE : Packet
{
    public CharacterInfoUpdateType UpdateType;
    public ulong Gold;
    public bool GoldDisplayed;
    public uint SkillPoints;
    public bool SkillPointsDisplayed;
    public ushort StatPoints;
    public byte HwanPoints;
    public uint SourceUniqueId; // where particles come from
    public uint APPoints;
    
    public SERVER_CHARACTER_INFO_UPDATE() : base(0x304E)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out UpdateType);
        switch (UpdateType)
        {
            case CharacterInfoUpdateType.Gold:
                TryRead(out Gold);
                TryRead(out GoldDisplayed);
                break;
            case CharacterInfoUpdateType.SP:
                TryRead(out SkillPoints);
                TryRead(out SkillPointsDisplayed);
                break;
            case CharacterInfoUpdateType.STP:
                TryRead(out StatPoints);
                break;
            case CharacterInfoUpdateType.HWAN:
                TryRead(out HwanPoints);
                TryRead(out SourceUniqueId);
                break;
            case CharacterInfoUpdateType.EGYPT_AP:
                TryRead(out APPoints);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(UpdateType);
        switch (UpdateType)
        {
            case CharacterInfoUpdateType.Gold:
                TryWrite(Gold);
                TryWrite(GoldDisplayed);
                break;
            case CharacterInfoUpdateType.SP:
                TryWrite(SkillPoints);
                TryWrite(SkillPointsDisplayed);
                break;
            case CharacterInfoUpdateType.STP:
                TryWrite(StatPoints);
                break;
            case CharacterInfoUpdateType.HWAN:
                TryWrite(HwanPoints);
                TryWrite(SourceUniqueId);
                break;
            case CharacterInfoUpdateType.EGYPT_AP:
                TryWrite(APPoints);
                break;
        }
        return this;
    }

    public static Task<Packet> ofGold(ulong gold, bool displayed)
    {
        return new SERVER_CHARACTER_INFO_UPDATE
        {
            UpdateType = CharacterInfoUpdateType.Gold,
            Gold = gold,
            GoldDisplayed = displayed
        }.Build();
    }

    public static Task<Packet> ofSkillPoints(uint skillPoints, bool displayed)
    {
        return new SERVER_CHARACTER_INFO_UPDATE
        {
            UpdateType = CharacterInfoUpdateType.SP,
            SkillPoints = skillPoints,
            SkillPointsDisplayed = displayed
        }.Build();
    }

    public static Task<Packet> ofStatPoints(ushort statPoints)
    {
        return new SERVER_CHARACTER_INFO_UPDATE
        {
            UpdateType = CharacterInfoUpdateType.STP,
            StatPoints = statPoints
        }.Build();
    }

    public static Task<Packet> ofHwanPoints(byte hwanPoints, uint sourceUniqueId)
    {
        return new SERVER_CHARACTER_INFO_UPDATE
        {
            UpdateType = CharacterInfoUpdateType.HWAN,
            HwanPoints = hwanPoints,
            SourceUniqueId = sourceUniqueId
        }.Build();
    }

    public static Task<Packet> ofAPPoints(uint apPoints)
    {
        return new SERVER_CHARACTER_INFO_UPDATE
        {
            UpdateType = CharacterInfoUpdateType.EGYPT_AP,
            APPoints = apPoints
        }.Build();
    }

}