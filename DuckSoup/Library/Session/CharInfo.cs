using API;
using API.ServiceFactory;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Session;

public class CharInfo : ICharInfo
{
    private Packet? _packet;
    
    private readonly Session _session;
    private readonly ISharedObjects _sharedObjects;

    public CharInfo(Session session)
    {
        _session = session;
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));

    }

    public void Read(Packet packet)
    {
        if(_packet == null)
        {
            _packet = new Packet(0x0000);
        }
        
        for (var i = 0; i < packet.GetBytes().Length; i++)
        {
            _packet.WriteUInt8(packet.ReadUInt8());
        }
    }

    public void Process()
    {
        var serverTime = _packet.ReadUInt32(); // * 4   uint    ServerTime               //SROTimeStamp
        var refObjId = _packet.ReadUInt32(); // 4   uint    RefObjID
        var scale = _packet.ReadUInt8(); // 1   byte    Scale
        var curLevel = _packet.ReadUInt8(); // 1   byte    CurLevel
        var maxLevel = _packet.ReadUInt8(); // 1   byte    MaxLevel
        var expOffset = _packet.ReadUInt64(); // 8   ulong   ExpOffset
        var sExpOffset = _packet.ReadUInt32(); // 4   uint    SExpOffset
        var remainGold = _packet.ReadUInt64(); // 8   ulong   RemainGold
        var remainSkillPoint = _packet.ReadUInt32(); // 4   uint    RemainSkillPoint
        var remainStatPoint = _packet.ReadUInt16(); // 2   ushort  RemainStatPoint
        var remainHwanCount = _packet.ReadUInt8(); // 1   byte    RemainHwanCount
        var gatheredExpPoint = _packet.ReadUInt32(); // 4   uint    GatheredExpPoint
        var hp = _packet.ReadUInt32(); // 4   uint    HP
        var mp = _packet.ReadUInt32(); // 4   uint    MP
        var autoInverstExp = _packet.ReadUInt8(); // 1   byte    AutoInverstExp
        var dailyPk = _packet.ReadUInt8(); // 1   byte    DailyPK
        var totalPk = _packet.ReadUInt16(); // 2   ushort  TotalPK
        var pkPenaltyPoint = _packet.ReadUInt32(); // 4   uint    PKPenaltyPoint
        var hwanLevel = _packet.ReadUInt8(); // 1   byte    HwanLevel
        _session.SessionData.State.PvpCape =
            (PVPCape)_packet
                .ReadUInt8(); // 1   byte    FreePVP           //0 = None, 1 = Red, 2 = Gray, 3 = Blue, 4 = White, 5 = Gold

        // //Inventory
        var inventorySize = _packet.ReadUInt8(); // 1   byte    Inventory.Size
        var inventoryItemCount = _packet.ReadUInt8(); // 1   byte    Inventory.ItemCount
        for (var i = 0; i < inventoryItemCount; i++) // for (int i = 0; i < Inventory.ItemCount; i++)
        {
            var itemSlot = _packet.ReadUInt8(); //     1   byte    item.Slot
            var itemRentType = _packet.ReadUInt32(); //     4   uint    item.RentType
            if (itemRentType == 1)
            {
                var itemRentInfoCanDelete = _packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoPeriodBeginTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodBeginTime
                var itemRentInfoPeriodEndTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodEndTime        
            }
            else if (itemRentType == 2)
            {
                var itemRentInfoCanDelete = _packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoCanRecharge = _packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanRecharge
                var itemRentInfoMeterRateTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.MeterRateTime        
            }
            else if (itemRentType == 3)
            {
                var itemRentInfoCanDelete = _packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoCanRecharge = _packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanRecharge
                var itemRentInfoPeriodBeginTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodBeginTime
                var itemRentInfoPeriodEndTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodEndTime   
                var itemRentInfoPackingTime =
                    _packet.ReadUInt32(); //         4   uint    item.RentInfo.PackingTime        
            }

            var itemRefItemId = _packet.ReadUInt32(); //     4   uint    item.RefItemID
            var itemFound = _sharedObjects.RefObjCommon.TryGetValue((int)itemRefItemId, out var item);

            if (!itemFound) continue;
            
            if (item.TypeID1 == 3)
            {
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    var itemOptLevel = _packet.ReadUInt8(); // 1   byte    item.OptLevel
                    var itemVariance = _packet.ReadUInt64(); // 8   ulong   item.Variance
                    var itemData = _packet.ReadUInt32(); // 4   uint    item.Data       //Durability
                    var itemMagParamNum = _packet.ReadUInt8(); // 1   byte    item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        var magParamType = _packet.ReadUInt32(); // 4   uint    magParam.Type
                        var magParamValue = _packet.ReadUInt32(); // 4   uint    magParam.Value                
                    }

                    var bindingOptionType = _packet.ReadUInt8(); // 1   byte    bindingOptionType   //1 = Socket
                    var bindingOptionCount = _packet.ReadUInt8(); // 1   byte    bindingOptionCount
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount; bindingOptionIndex++)
                    {
                        var bindingOptionSlot = _packet.ReadUInt8(); // 1   byte bindingOption.Slot
                        var bindingOptionId = _packet.ReadUInt32(); // 4   uint bindingOption.ID
                        var bindingOptionParam1 = _packet.ReadUInt32(); // 4   uint bindingOption.nParam1
                    }

                    var bindingOptionType2 =
                        _packet.ReadUInt8(); // 1   byte    bindingOptionType   //2 = Advanced elixir
                    var bindingOptionCount2 = _packet.ReadUInt8(); // 1   byte    bindingOptionCount2
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount2; bindingOptionIndex++)
                    {
                        var bindingOptionSlot = _packet.ReadUInt8(); // 1   byte bindingOption.Slot
                        var bindingOptionId = _packet.ReadUInt32(); // 4   uint bindingOption.ID
                        var bindingOptionOptValue = _packet.ReadUInt32(); // 4   uint bindingOption.OptValue
                    }
                }
                else if (item.TypeID2 == 2)
                {
                    if (item.TypeID3 == 1)
                    {
                        //ITEM_COS_P
                        var cosState = _packet.ReadUInt8(); //1   byte    State
                        if (cosState == 2 || cosState == 3 || cosState == 4)
                        {
                            var cosRefObjId = _packet.ReadUInt32(); // 4 uint RefObjID
                            var cosName = _packet.ReadAscii(); // 2 ushort Name.Length //     * string Name
                            if (item.TypeID4 == 2)
                            {
                                //ITEM_COS_P (Ability)
                                var cosSecondsToRentEndTime = _packet.ReadUInt32(); // 4 uint SecondsToRentEndTime
                            }

                            // Maybe?!
                            // might be service thing
                            var hasInventoryTime = _packet.ReadUInt8(); // 1 byte unkByte0

                            if (hasInventoryTime == 0x1)
                            {
                                // Perhaps inventory span
                                var unk1222 = _packet.ReadUInt8(); // NANI
                                var unk1223 = _packet.ReadUInt32(); // THE
                                var unk1224 = _packet.ReadUInt32(); // FUCK
                                if(unk1224 == 5) {
                                    // Special Thanks to BimBum1337
                                    // https://i.rapture.pw/BAKE5/ZEqISAFo33.png/raw
                                    var unk1225 = _packet.ReadUInt32(); // ?!
                                    var unk1226 = _packet.ReadUInt8();
                                }
                                //Global.Logger.InfoFormat("{0}, {1}, {2}, {3}, {4}", unk1222, unk1223, unk1224,
                                //    unk1225, unk1226);
                            }
                        }
                    }
                    else if (item.TypeID3 == 2)
                    {
                        //ITEM_ETC_TRANS_MONSTER
                        var etcRefObjId = _packet.ReadUInt32(); // 4   uint    RefObjID
                    }
                    else if (item.TypeID3 == 3)
                    {
                        //MAGIC_CUBE
                        var quantity =
                            _packet
                                .ReadUInt32(); // 4   uint    Quantity        //Do not confuse with StackCount, this indicates the amount of elixirs in the cube
                    }
                }
                else if (item.TypeID2 == 3)
                {
                    //ITEM_ETC
                    var itemStackCount = _packet.ReadUInt16(); // 2   ushort  item.StackCount

                    if (item.TypeID3 == 11)
                    {
                        if (item.TypeID4 == 1 || item.TypeID4 == 2)
                        {
                            //MAGICSTONE, ATTRSTONE
                            var attributeAssimilationProbability =
                                _packet.ReadUInt8(); // 1   byte    AttributeAssimilationProbability
                        }
                    }
                    else if (item.TypeID3 == 14 && item.TypeID4 == 2)
                    {
                        //ITEM_MALL_GACHA_CARD_WIN
                        //ITEM_MALL_GACHA_CARD_LOSE
                        var magParamNum = _packet.ReadUInt8(); // 1   byte    item.MagParamCount
                        for (var paramIndex = 0; paramIndex < magParamNum; paramIndex++)
                        {
                            var magParamType = _packet.ReadUInt32(); //4   uint magParam.Type
                            var magParamValue = _packet.ReadUInt32(); //4   uint magParam.Value
                        }
                    }
                }
            }
        }

        //AvatarInventory
        var avatarInventorySize = _packet.ReadUInt8(); // 1 byte AvatarInventory.Size
        var avatarInventoryItemCount = _packet.ReadUInt8(); // 1 byte AvatarInventory.ItemCount
        for (var i = 0; i < avatarInventoryItemCount; i++)
        {
            _packet.ReadUInt8(); // 1 byte item.Slot
            var itemRentType = _packet.ReadUInt32(); // 4 uint item.RentType
            if (itemRentType == 1)
            {
                _packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                _packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodBeginTime
                _packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodEndTime
            }
            else if (itemRentType == 2)
            {
                _packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                _packet.ReadUInt16(); // 2 ushort item.RentInfo.CanRecharge
                _packet.ReadUInt32(); // 4 uint item.RentInfo.MeterRateTime
            }
            else if (itemRentType == 3)
            {
                _packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                _packet.ReadUInt16(); // 2 ushort item.RentInfo.CanRecharge
                _packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodBeginTime
                _packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodEndTime
                _packet.ReadUInt32(); // 4 uint item.RentInfo.PackingTime
            }

            var itemRefItemId = _packet.ReadUInt32(); // 4 uint item.RefItemID
            var itemFound = _sharedObjects.RefObjCommon.TryGetValue((int)itemRefItemId, out var item);
            if (!itemFound)
            {
                continue;
            }
            
            if (item.TypeID1 == 3)
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    _packet.ReadUInt8(); // 1 byte item.OptLevel
                    _packet.ReadUInt64(); // 8 ulong item.Variance
                    _packet.ReadUInt32(); // 4 uint item.Data //Durability
                    var itemMagParamNum = _packet.ReadUInt8(); // 1 byte item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        _packet.ReadUInt32(); // 4 uint magParam.Type
                        _packet.ReadUInt32(); // 4 uint magParam.Value
                    }

                    _packet.ReadUInt8(); // 1 byte bindingOptionType //1 = Socket
                    var bindingOptionCount = _packet.ReadUInt8(); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount;
                         bindingOptionIndex++)
                    {
                        _packet.ReadUInt8(); // 1 byte bindingOption.Slot
                        _packet.ReadUInt32(); // 4 uint bindingOption.ID
                        _packet.ReadUInt32(); // 4 uint bindingOption.nParam1
                    }

                    _packet.ReadUInt8(); // 1 byte bindingOptionType //2 = Advanced elixir
                    var bindingOptionCount2 = _packet.ReadUInt8(); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount2;
                         bindingOptionIndex++)
                    {
                        _packet.ReadUInt8(); // 1 byte bindingOption.Slot
                        _packet.ReadUInt32(); // 4 uint bindingOption.ID
                        _packet.ReadUInt32(); // 4 uint bindingOption.OptValue
                    }
                }
        }

        _packet.ReadUInt8(); //1 byte unkByte1 //not a counter

        //Masteries
        var nextMastery = _packet.ReadUInt8(); // 1   byte    nextMastery
        while (nextMastery == 1)
        {
            var masteryId = _packet.ReadUInt32(); // 4   uint    mastery.ID
            var masteryLevel = _packet.ReadUInt8(); // 1   byte    mastery.Level   
            nextMastery = _packet.ReadUInt8(); // 1   byte    nextMastery
        }

        _packet.ReadUInt8(); // 1   byte    unkByte2    //not a counter

        //Skills
        var nextSkill = _packet.ReadUInt8(); // 1   byte    nextSkill
        while (nextSkill == 1)
        {
            var skillId = _packet.ReadUInt32(); // 4   uint    skill.ID
            var skillEnabled = _packet.ReadUInt8(); // 1   byte    skill.Enabled   

            nextSkill = _packet.ReadUInt8(); // 1   byte    nextSkill
        }

        //Quests
        var completedQuestCount = _packet.ReadUInt16(); // 2   ushort  CompletedQuestCount
        var completedQuests = _packet.ReadUInt32Array(completedQuestCount); // *   uint[]  CompletedQuests

        var activeQuestCount = _packet.ReadUInt8(); // 1   byte    ActiveQuestCount
        for (var activeQuestIndex = 0; activeQuestIndex < activeQuestCount; activeQuestIndex++)
        {
            var questRefQuestId = _packet.ReadUInt32(); // 4   uint    quest.RefQuestID
            var questAchievementCount = _packet.ReadUInt8(); // 1   byte    quest.AchievementCount
            var questRequiresAutoShareParty = _packet.ReadUInt8(); // 1   byte    quest.RequiresAutoShareParty
            var questType = _packet.ReadUInt8(); // 1   byte    quest.Type
            if (questType == 28)
            {
                var questRemainingTime = _packet.ReadUInt32(); // 4   uint    remainingTime
            }

            var questStatus = _packet.ReadUInt8(); // 1   byte    quest.Status

            if (questType != 8)
            {
                var questObjectiveCount = _packet.ReadUInt8(); // 1   byte    quest.ObjectiveCount
                for (var objectiveIndex = 0; objectiveIndex < questObjectiveCount; objectiveIndex++)
                {
                    var questObjectiveId = _packet.ReadUInt8(); // 1   byte    objective.ID
                    var questObjectiveStatus =
                        _packet.ReadUInt8(); // 1   byte    objective.Status        //0 = Done, 1  = On
                    var questObjectiveName =
                        _packet.ReadAscii(); // 2   ushort  objective.Name.Length // *   string  objective.Name
                    var objectiveTaskCount = _packet.ReadUInt8(); // 1   byte    objective.TaskCount
                    for (var taskIndex = 0; taskIndex < objectiveTaskCount; taskIndex++)
                    {
                        var questTaskValue = _packet.ReadUInt32(); // 4   uint    task.Value
                    }
                }
            }

            if (questType == 88)
            {
                var refObjCount = _packet.ReadUInt8(); // 1   byte    RefObjCount
                for (var refObjIndex = 0; refObjIndex < refObjCount; refObjIndex++)
                    _packet.ReadUInt32(); // 4   uint    RefObjID    //NPCs
            }
        }

        _packet.ReadUInt8(); // 1   byte    unkByte3        //Structure changes!!!

        //CollectionBook
        var startedCollectionCount = _packet.ReadUInt32(); // 4   uint    CollectionBookStartedThemeCount
        for (var i = 0; i < startedCollectionCount; i++)
        {
            var themeIndex = _packet.ReadUInt32(); // 4   uint    theme.Index
            var themeStartedDateTime = _packet.ReadUInt32(); // 4   uint    theme.StartedDateTime   //SROTimeStamp
            var themePages = _packet.ReadUInt32(); // 4   uint    theme.Pages
        }

        _session.SessionData.UniqueCharId = _packet.ReadUInt32(); // 4   uint    UniqueID

        //Position
        _session.SessionData.LatestRegionId = _packet.ReadUInt16(); // 2   ushort  Position.RegionID
        _session.SessionData.PositionX = _packet.ReadFloat(); // 4   float   Position.X
        _session.SessionData.PositionY = _packet.ReadFloat(); // 4   float   Position.Y
        _session.SessionData.PositionZ = _packet.ReadFloat(); // 4   float   Position.Z
        var positionAngle = _packet.ReadUInt16(); // 2   ushort  Position.Angle

        //Movement
        var movementHasDestination = _packet.ReadUInt8(); // 1   byte    Movement.HasDestination
        var movementType = _packet.ReadUInt8(); // 1   byte    Movement.Type
        if (movementHasDestination == 1)
        {
            var movementDestionationRegion = _packet.ReadUInt16(); // 2   ushort  Movement.DestinationRegion        
            if (_session.SessionData.LatestRegionId < short.MaxValue)
            {
                //World
                var movementDestinationOffsetX = _packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetX
                var movementDestinationOffsetY = _packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetY
                var movementDestinationOffsetZ = _packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetZ
            }
            else
            {
                //Dungeon
                var movementDestinationOffsetX = _packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetX
                var movementDestinationOffsetY = _packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetY
                var movementDestinationOffsetZ = _packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetZ
            }
        }
        else
        {
            var movementSource =
                _packet.ReadUInt8(); // 1   byte    Movement.Source     //0 = Spinning, 1 = Sky-/Key-walking
            var movementAngle =
                _packet.ReadUInt16(); // 2   ushort  Movement.Angle      //Represents the new angle, character is looking at
        }

        //State
        _session.SessionData.State.LifeState =
            (LifeState)_packet.ReadUInt8(); // 1   byte    State.LifeState         //1 = Alive, 2 = Dead
        _packet.ReadUInt8(); // 1   byte    State.unkByte0
        _session.SessionData.State.MotionState =
            (MotionState)_packet
                .ReadUInt8(); // 1   byte    State.MotionState       //0 = None, 2 = Walking, 3 = Running, 4 = Sitting
        _session.SessionData.State.BodyState = (BodyState)_packet
            .ReadUInt8(); // 1   byte    State.Status            //0 = None, 1 = Hwan, 2 = Untouchable, 3 = GameMasterInvincible, 5 = GameMasterInvisible, 5 = ?, 6 = Stealth, 7 = Invisible
        var stateWalkSpeed = _packet.ReadFloat(); // 4   float   State.WalkSpeed
        var stateRunSpeed = _packet.ReadFloat(); // 4   float   State.RunSpeed
        var stateHwanSpeed = _packet.ReadFloat(); // 4   float   State.HwanSpeed
        var stateBuffCount = _packet.ReadUInt8(); // 1   byte    State.BuffCount

        for (var i = 0; i < stateBuffCount; i++)
        {
            var buffRefSkillId = _packet.ReadUInt32(); // 4   uint    Buff.RefSkillID
            var buffDuration = _packet.ReadUInt32(); // 4   uint    Buff.Duration

            var skillFound = _sharedObjects.RefSkill.TryGetValue((int)buffRefSkillId, out var skill);

            if (!skillFound) continue;
            if (skill.ParamsContains(1701213281))
            {
                //1701213281 -> atfe -> "auto transfer effect" like Recovery Division
                var isCreator = _packet.ReadUInt8(); // 1   bool    IsCreator
            }
        }

        var name = _packet.ReadAscii(); // 2   ushort  Name.Length // *   string  Name
        _session.SessionData.Charname = name;
        var jobName = _packet.ReadAscii(); // 2   ushort  JobName.Length // *   string  JobName
        _session.SessionData.JobType = (Job)_packet.ReadUInt8(); // 1   byte    JobType
        var jobLevel = _packet.ReadUInt8(); // 1   byte    JobLevel
        var jobExp = _packet.ReadUInt32(); // 4   uint    JobExp
        var jobContribution = _packet.ReadUInt32(); // 4   uint    JobContribution
        var jobReward = _packet.ReadUInt32(); // 4   uint    JobReward
        _session.SessionData.State.PvpState =
            (PvpState)_packet.ReadUInt8(); // 1   byte    PVPState                //0 = White, 1 = Purple, 2 = Red
        _session.SessionData.OnTransport = _packet.ReadBool(); // 1   byte    TransportFlag
        _session.SessionData.State.BattleState = (BattleState)_packet.ReadUInt8(); // 1   byte    InCombat
        if (_session.SessionData.OnTransport)
        {
            _session.SessionData.TransportUniqueId = _packet.ReadUInt32(); // 4   uint    Transport.UniqueID
        }

        var pvpFlag =
            _packet.ReadUInt8(); // 1   byte    PVPFlag                 //0 = Red Side, 1 = Blue Side, 0xFF = None
        var guideFlag = _packet.ReadUInt64(); // 8   ulong   GuideFlag
        var jid = _packet.ReadUInt32(); // 4   uint    JID
        var gmFlag = _packet.ReadUInt8(); // 1   byte    GMFlag

        var activationFlag =
            _packet.ReadUInt8(); // 1   byte    ActivationFlag          //ConfigType:0 --> (0 = Not activated, 7 = activated)
        var hotkeyCount = _packet.ReadUInt8(); // 1   byte    Hotkeys.Count           //ConfigType:1
        for (var i = 0; i < hotkeyCount; i++)
        {
            var hotkeySlotSeq = _packet.ReadUInt8(); // 1   byte    hotkey.SlotSeq
            var hotkeySlotContentType = _packet.ReadUInt8(); // 1   byte    hotkey.SlotContentType
            var hotkeySlotData = _packet.ReadUInt32(); // 4   uint    hotkey.SlotData
        }

        var autoHpConfig = _packet.ReadUInt16(); // 2   ushort  AutoHPConfig            //ConfigType:11
        var autoMpConfig = _packet.ReadUInt16(); // 2   ushort  AutoMPConfig            //ConfigType:12
        var autoUniversalConfig = _packet.ReadUInt16(); // 2   ushort  AutoUniversalConfig     //ConfigType:13
        var autoPotionDelay = _packet.ReadUInt8(); // 1   byte    AutoPotionDelay         //ConfigType:14

        var blockedWhisperCount = _packet.ReadUInt8(); // 1   byte    blockedWhisperCount
        for (var i = 0; i < blockedWhisperCount; i++)
        {
            var target = _packet.ReadAscii(); // 2   ushort  Target.Length // *   string  Target
        }

        _packet.ReadUInt32(); // 4   uint    unkUShort0      //Structure changes!!!
        _packet.ReadUInt8(); // 1   byte    unkByte4        //Structure changes!!!
    }

    public void Clear()
    {
        _packet = null;
    }

    public Packet GetPacket()
    {
        return _packet;
    }
}