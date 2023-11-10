using System.Diagnostics;
using System.Threading.Tasks;
using API.Session;
using Database.VSRO188;
using PacketLibrary.VSRO188.Agent.Objects;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

// ReSharper disable UnusedVariable
public class CharInfo : ICharInfo
{
    private Packet? _packet = new(0x3013);
    private bool _debug = false;

    public void Initialize()
    {
        _packet = new Packet(0x3013, false, true);
        TargetPosition = new Position(0, 0);
    }

    public void Append(Packet packet)
    {
        if (_packet == null)
        {
            return;
        }

        Stopwatch watch = null;
        if (_debug)
        {
            watch = Stopwatch.StartNew();
        }

        for (var i = 0; i < packet.GetBytes().Length; i++)
        {
            packet.TryRead(out byte b);
            _packet.TryWrite(b);
        }

        if (_debug)
        {
            watch.Stop();
            double ticks = watch.ElapsedTicks;
            var seconds = ticks / Stopwatch.Frequency;
            var milliseconds = ticks / Stopwatch.Frequency * 1000;
            var nanoseconds = ticks / Stopwatch.Frequency * 1000000000;
            Log.Information("CharInfo Append: {0}ms", milliseconds);
        }
    }

    public async Task Read()
    {
        if (_packet == null)
        {
            return;
        }

        Stopwatch watch = null;
        if (_debug)
        {
            watch = Stopwatch.StartNew();
        }

        _packet.ToReadOnly();

        # region general

        _packet.TryRead(out ServerTime); // * 4   uint    ServerTime               //SROTimeStamp
        _packet.TryRead(out RefObjId); // 4   uint    RefObjID
        _packet.TryRead(out Scale); // 1   byte    Scale
        _packet.TryRead(out CurLevel); // 1   byte    CurLevel
        _packet.TryRead(out MaxLevel); // 1   byte    MaxLevel
        _packet.TryRead(out ExpOffset); // 8   ulong   ExpOffset
        _packet.TryRead(out SExpOffset); // 4   uint    SExpOffset
        _packet.TryRead(out RemainGold); // 8   ulong   RemainGold
        _packet.TryRead(out RemainSkillPoint); // 4   uint    RemainSkillPoint
        _packet.TryRead(out RemainStatPoint); // 2   ushort  RemainStatPoint
        _packet.TryRead(out RemainHwanCount); // 1   byte    RemainHwanCount
        _packet.TryRead(out GatheredExpPoint); // 4   uint    GatheredExpPoint
        _packet.TryRead(out Hp); // 4   uint    HP
        _packet.TryRead(out Mp); // 4   uint    MP
        _packet.TryRead(out AutoInverstExp); // 1   byte    AutoInverstExp
        _packet.TryRead(out DailyPk); // 1   byte    DailyPK
        _packet.TryRead(out TotalPk); // 2   ushort  TotalPK
        _packet.TryRead(out PkPenaltyPoint); // 4   uint    PKPenaltyPoint
        _packet.TryRead(out HwanLevel); // 1   byte    HwanLevel
        _packet.TryRead(
            out PvpCape); // 1   byte    FreePVP           //0 = None, 1 = Red, 2 = Gray, 3 = Blue, 4 = White, 5 = Gold

        #endregion

        #region Inventory

        _packet.TryRead(out byte inventorySize); // 1   byte    Inventory.Size
        _packet.TryRead(out byte inventoryItemCount); // 1   byte    Inventory.ItemCount
        for (var i = 0; i < inventoryItemCount; i++) // for (int i = 0; i < Inventory.ItemCount; i++)
        {
            _packet.TryRead(out byte itemSlot); //     1   byte    item.Slot
            _packet.TryRead(out uint itemRentType); //     4   uint    item.RentType
            if (itemRentType == 1)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); //         2   ushort  item.RentInfo.CanDelete
                _packet.TryRead(
                    out uint itemRentInfoPeriodBeginTime); //         4   uint    item.RentInfo.PeriodBeginTime
                _packet.TryRead(
                    out uint itemRentInfoPeriodEndTime); //         4   uint    item.RentInfo.PeriodEndTime        
            }
            else if (itemRentType == 2)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); //         2   ushort  item.RentInfo.CanDelete
                _packet.TryRead(out ushort itemRentInfoCanRecharge); //         2   ushort  item.RentInfo.CanRecharge
                _packet.TryRead(
                    out uint itemRentInfoMeterRateTime); //         4   uint    item.RentInfo.MeterRateTime        
            }
            else if (itemRentType == 3)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); //         2   ushort  item.RentInfo.CanDelete
                _packet.TryRead(out ushort itemRentInfoCanRecharge); //         2   ushort  item.RentInfo.CanRecharge
                _packet.TryRead(
                    out uint itemRentInfoPeriodBeginTime); //         4   uint    item.RentInfo.PeriodBeginTime
                _packet.TryRead(
                    out uint itemRentInfoPeriodEndTime); //         4   uint    item.RentInfo.PeriodEndTime   
                _packet.TryRead(
                    out uint itemRentInfoPackingTime); //         4   uint    item.RentInfo.PackingTime        
            }

            _packet.TryRead(out uint itemRefItemId); //     4   uint    item.RefItemID
            var item = await Cache.GetRefObjCommonAsync((int)itemRefItemId);
            if (item == null) continue;

            if (item.TypeID1 == 3)
            {
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    _packet.TryRead(out byte itemOptLevel); // 1   byte    item.OptLevel
                    _packet.TryRead(out ulong itemVariance); // 8   ulong   item.Variance
                    _packet.TryRead(out uint itemData); // 4   uint    item.Data       //Durability
                    _packet.TryRead(out byte itemMagParamNum); // 1   byte    item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        _packet.TryRead(out uint magParamType); // 4   uint    magParam.Type
                        _packet.TryRead(out uint magParamValue); // 4   uint    magParam.Value                
                    }

                    _packet.TryRead(out byte bindingOptionType); // 1   byte    bindingOptionType   //1 = Socket
                    _packet.TryRead(out byte bindingOptionCount); // 1   byte    bindingOptionCount
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount; bindingOptionIndex++)
                    {
                        _packet.TryRead(out byte bindingOptionSlot); // 1   byte bindingOption.Slot
                        _packet.TryRead(out uint bindingOptionId); // 4   uint bindingOption.ID
                        _packet.TryRead(out uint bindingOptionParam1); // 4   uint bindingOption.nParam1
                    }

                    _packet.TryRead(
                        out byte bindingOptionType2); // 1   byte    bindingOptionType   //2 = Advanced elixir
                    _packet.TryRead(out byte bindingOptionCount2); // 1   byte    bindingOptionCount2
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount2; bindingOptionIndex++)
                    {
                        _packet.TryRead(out byte bindingOptionSlot); // 1   byte bindingOption.Slot
                        _packet.TryRead(out uint bindingOptionId); // 4   uint bindingOption.ID
                        _packet.TryRead(out uint bindingOptionOptValue); // 4   uint bindingOption.OptValue
                    }
                }
                else if (item.TypeID2 == 2)
                {
                    if (item.TypeID3 == 1)
                    {
                        //ITEM_COS_P
                        _packet.TryRead(out byte cosState); //1   byte    State
                        if (cosState == 2 || cosState == 3 || cosState == 4)
                        {
                            _packet.TryRead(out uint cosRefObjId); // 4 uint RefObjID
                            _packet.TryRead(out var cosName); // 2 ushort Name.Length //     * string Name
                            if (item.TypeID4 == 2)
                                //ITEM_COS_P (Ability)
                                _packet.TryRead(out uint cosSecondsToRentEndTime); // 4 uint SecondsToRentEndTime

                            // Maybe?!
                            // might be service thing
                            _packet.TryRead(out byte hasInventoryTime); // 1 byte unkByte0

                            if (hasInventoryTime == 0x1)
                            {
                                // Perhaps inventory span
                                _packet.TryRead(out byte unk1222); // NANI
                                _packet.TryRead(out uint unk1223); // THE
                                _packet.TryRead(out uint unk1224); // FUCK
                                if (unk1224 == 5)
                                {
                                    // Special Thanks to BimBum1337
                                    // https://i.rapture.pw/BAKE5/ZEqISAFo33.png/raw
                                    _packet.TryRead(out uint unk1225); // ?!
                                    _packet.TryRead(out byte unk1226);
                                }
                            }
                        }
                    }
                    else if (item.TypeID3 == 2)
                    {
                        //ITEM_ETC_TRANS_MONSTER
                        _packet.TryRead(out uint etcRefObjId); // 4   uint    RefObjID
                    }
                    else if (item.TypeID3 == 3)
                    {
                        //MAGIC_CUBE
                        _packet.TryRead(
                            out uint quantity); // 4   uint    Quantity        //Do not confuse with StackCount, this indicates the amount of elixirs in the cube
                    }
                }
                else if (item.TypeID2 == 3)
                {
                    //ITEM_ETC
                    _packet.TryRead(out ushort itemStackCount); // 2   ushort  item.StackCount

                    if (item.TypeID3 == 11)
                    {
                        if (item.TypeID4 == 1 || item.TypeID4 == 2)
                            //MAGICSTONE, ATTRSTONE
                            _packet.TryRead(
                                out byte attributeAssimilationProbability); // 1   byte    AttributeAssimilationProbability
                    }
                    else if (item.TypeID3 == 14 && item.TypeID4 == 2)
                    {
                        //ITEM_MALL_GACHA_CARD_WIN
                        //ITEM_MALL_GACHA_CARD_LOSE
                        _packet.TryRead(out byte magParamNum); // 1   byte    item.MagParamCount
                        for (var paramIndex = 0; paramIndex < magParamNum; paramIndex++)
                        {
                            _packet.TryRead(out uint magParamType); //4   uint magParam.Type
                            _packet.TryRead(out uint magParamValue); //4   uint magParam.Value
                        }
                    }
                }
            }
        }

        #endregion

        #region AvatarInventory

        _packet.TryRead(out byte avatarInventorySize); // 1 byte AvatarInventory.Size
        _packet.TryRead(out byte avatarInventoryItemCount); // 1 byte AvatarInventory.ItemCount
        for (var i = 0; i < avatarInventoryItemCount; i++)
        {
            _packet.TryRead(out byte itemSlot); // 1 byte item.Slot
            _packet.TryRead(out uint itemRentType); // 4 uint item.RentType
            if (itemRentType == 1)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); // 2 ushort item.RentInfo.CanDelete
                _packet.TryRead(out uint itemRentInfoPeriodBeginTime); // 4 uint item.RentInfo.PeriodBeginTime
                _packet.TryRead(out uint itemRentInfoPeriodEndTime); // 4 uint item.RentInfo.PeriodEndTime
            }
            else if (itemRentType == 2)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); // 2 ushort item.RentInfo.CanDelete
                _packet.TryRead(out ushort itemRentInfoCanRecharge); // 2 ushort item.RentInfo.CanRecharge
                _packet.TryRead(out uint itemRentInfoMeterRateTime); // 4 uint item.RentInfo.MeterRateTime
            }
            else if (itemRentType == 3)
            {
                _packet.TryRead(out ushort itemRentInfoCanDelete); // 2 ushort item.RentInfo.CanDelete
                _packet.TryRead(out ushort itemRentInfoCanRecharge); // 2 ushort item.RentInfo.CanRecharge
                _packet.TryRead(out uint itemRentInfoPeriodBeginTime); // 4 uint item.RentInfo.PeriodBeginTime
                _packet.TryRead(out uint itemRentInfoPeriodEndTime); // 4 uint item.RentInfo.PeriodEndTime
                _packet.TryRead(out uint itemRentInfoPackingTime); // 4 uint item.RentInfo.PackingTime
            }

            _packet.TryRead(out uint itemRefItemId); // 4 uint item.RefItemID
            var item = await Cache.GetRefObjCommonAsync((int)itemRefItemId);
            if (item == null) continue;

            if (item.TypeID1 == 3)
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    _packet.TryRead(out byte itemOptLevel); // 1 byte item.OptLevel
                    _packet.TryRead(out ulong itemVariance); // 8 ulong item.Variance
                    _packet.TryRead(out uint itemData); // 4 uint item.Data //Durability
                    _packet.TryRead(out byte itemMagParamNum); // 1 byte item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        _packet.TryRead(out uint magParamType); // 4 uint magParam.Type
                        _packet.TryRead(out uint magParamValue); // 4 uint magParam.Value
                    }

                    _packet.TryRead(out byte bindingOptionType); // 1 byte bindingOptionType //1 = Socket
                    _packet.TryRead(out byte bindingOptionCount); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount;
                         bindingOptionIndex++)
                    {
                        _packet.TryRead(out byte bindingOptionSlot); // 1 byte bindingOption.Slot
                        _packet.TryRead(out uint bindingOptionID); // 4 uint bindingOption.ID
                        _packet.TryRead(out uint bindingOptionOptValue); // 4 uint bindingOption.nParam1
                    }

                    _packet.TryRead(out byte bindingOptionType2); // 1 byte bindingOptionType //2 = Advanced elixir
                    _packet.TryRead(out byte bindingOptionCount2); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount2;
                         bindingOptionIndex++)
                    {
                        _packet.TryRead(out byte bindingOptionSlot); // 1 byte bindingOption.Slot
                        _packet.TryRead(out uint bindingOptionID); // 4 uint bindingOption.ID
                        _packet.TryRead(out uint bindingOptionOptValue); // 4 uint bindingOption.OptValue
                    }
                }
        }

        #endregion

        _packet.TryRead(out byte unkByte1); //1 byte unkByte1 //not a counter

        #region Masteries

        _packet.TryRead(out byte nextMastery); // 1   byte    nextMastery
        while (nextMastery == 1)
        {
            _packet.TryRead(out uint masteryId); // 4   uint    mastery.ID
            _packet.TryRead(out byte masteryLevel); // 1   byte    mastery.Level   
            _packet.TryRead(out nextMastery); // 1   byte    nextMastery
        }

        #endregion

        _packet.TryRead(out byte unkByte2); // 1   byte    unkByte2    //not a counter

        #region Skills

        _packet.TryRead(out byte nextSkill); // 1   byte    nextSkill
        while (nextSkill == 1)
        {
            _packet.TryRead(out uint skillId); // 4   uint    skill.ID
            _packet.TryRead(out byte skillEnabled); // 1   byte    skill.Enabled   

            _packet.TryRead(out nextSkill); // 1   byte    nextSkill
        }

        #endregion

        #region Quests

        _packet.TryRead(out ushort completedQuestCount); // 2   ushort  CompletedQuestCount
        var completedQuests = new uint[completedQuestCount];
        for (ushort i = 0; i < completedQuestCount; i++) // *   uint[]  CompletedQuests
        {
            _packet.TryRead(out uint quest);
            completedQuests[i] = quest;
        }

        _packet.TryRead(out byte activeQuestCount); // 1   byte    ActiveQuestCount
        for (var activeQuestIndex = 0; activeQuestIndex < activeQuestCount; activeQuestIndex++)
        {
            _packet.TryRead(out uint questRefQuestId); // 4   uint    quest.RefQuestID
            _packet.TryRead(out byte questAchievementCount); // 1   byte    quest.AchievementCount
            _packet.TryRead(out byte questRequiresAutoShareParty); // 1   byte    quest.RequiresAutoShareParty
            _packet.TryRead(out byte questType); // 1   byte    quest.Type
            if (questType == 28) _packet.TryRead(out uint questRemainingTime); // 4   uint    remainingTime

            _packet.TryRead(out byte questStatus); // 1   byte    quest.Status

            if (questType != 8)
            {
                _packet.TryRead(out byte questObjectiveCount); // 1   byte    quest.ObjectiveCount
                for (var objectiveIndex = 0; objectiveIndex < questObjectiveCount; objectiveIndex++)
                {
                    _packet.TryRead(out byte questObjectiveId); // 1   byte    objective.ID
                    _packet.TryRead(
                        out byte questObjectiveStatus); // 1   byte    objective.Status        //0 = Done, 1  = On
                    _packet.TryRead(
                        out var questObjectiveName); // 2   ushort  objective.Name.Length // *   string  objective.Name
                    _packet.TryRead(out byte objectiveTaskCount); // 1   byte    objective.TaskCount
                    for (var taskIndex = 0; taskIndex < objectiveTaskCount; taskIndex++)
                        _packet.TryRead(out uint questTaskValue); // 4   uint    task.Value
                }
            }

            if (questType == 88)
            {
                _packet.TryRead(out byte refObjCount); // 1   byte    RefObjCount
                for (var refObjIndex = 0; refObjIndex < refObjCount; refObjIndex++)
                    _packet.TryRead(out uint questRefObjId); // 4   uint    RefObjID    //NPCs
            }
        }

        #endregion

        _packet.TryRead(out byte unkByte3); // 1   byte    unkByte3        //Structure changes!!!

        #region CollectionBook

        _packet.TryRead(out uint startedCollectionCount); // 4   uint    CollectionBookStartedThemeCount
        for (var i = 0; i < startedCollectionCount; i++)
        {
            _packet.TryRead(out uint themeIndex); // 4   uint    theme.Index
            _packet.TryRead(out uint themeStartedDateTime); // 4   uint    theme.StartedDateTime   //SROTimeStamp
            _packet.TryRead(out uint themePages); // 4   uint    theme.Pages
        }

        #endregion

        #region EntityData

        _packet.TryRead(out UniqueCharId); // 4   uint    UniqueID


        //Position
        // _packet.TryRead(out ushort latestRegionId); // 2   ushort  Position.RegionID
        // _packet.TryRead(out float positionX); // 4   float   Position.X
        // _packet.TryRead(out float positionY); // 4   float   Position.Y
        // _packet.TryRead(out float positionZ); // 4   float   Position.Z
        // _packet.TryRead(out ushort positionAngle); // 2   ushort  Position.Angle
        CurPosition = Position.FromPacket(_packet);

        //Movement
        _packet.TryRead(out byte movementHasDestination); // 1   byte    Movement.HasDestination
        _packet.TryRead(out byte movementType); // 1   byte    Movement.Type
        if (movementHasDestination == 1)
        {
            _packet.TryRead(out ushort movementDestionationRegion); // 2   ushort  Movement.DestinationRegion        
            if (movementDestionationRegion < short.MaxValue)
            {
                //World
                _packet.TryRead(out ushort movementDestinationOffsetX); // 2   ushort  Movement.DestinationOffsetX
                _packet.TryRead(out ushort movementDestinationOffsetY); // 2   ushort  Movement.DestinationOffsetY
                _packet.TryRead(out ushort movementDestinationOffsetZ); // 2   ushort  Movement.DestinationOffsetZ
            }
            else
            {
                //Dungeon
                _packet.TryRead(out uint movementDestinationOffsetX); // 4   uint  Movement.DestinationOffsetX
                _packet.TryRead(out uint movementDestinationOffsetY); // 4   uint  Movement.DestinationOffsetY
                _packet.TryRead(out uint movementDestinationOffsetZ); // 4   uint  Movement.DestinationOffsetZ
            }
        }
        else
        {
            _packet.TryRead(
                out byte movementSource); // 1   byte    Movement.Source     //0 = Spinning, 1 = Sky-/Key-walking
            _packet.TryRead(
                out ushort movementAngle); // 2   ushort  Movement.Angle      //Represents the new angle, character is looking at
        }
        // Movement movement = Movement.MotionFromPacket(_packet);

        //State
        // _packet.TryRead(out LifeState); // 1   byte    State.LifeState         //1 = Alive, 2 = Dead
        // _packet.TryRead(out Unkbyte0); // 1   byte    State.unkByte0
        // _packet.TryRead(
        //     out MotionState); // 1   byte    State.MotionState       //0 = None, 2 = Walking, 3 = Running, 4 = Sitting
        // _packet.TryRead(
        //     out BodyState); // 1   byte    State.Status            //0 = None, 1 = Hwan, 2 = Untouchable, 3 = GameMasterInvincible, 5 = GameMasterInvisible, 5 = ?, 6 = Stealth, 7 = Invisible
        // _packet.TryRead(out WalkSpeed); // 4   float   State.WalkSpeed
        // _packet.TryRead(out RunSpeed); // 4   float   State.RunSpeed
        // _packet.TryRead(out HwanSpeed); // 4   float   State.HwanSpeed
        //
        // _packet.TryRead(out byte stateBuffCount); // 1   byte    State.BuffCount
        // for (var i = 0; i < stateBuffCount; i++)
        // {
        //     _packet.TryRead(out uint buffRefSkillId); // 4   uint    Buff.RefSkillID
        //     _packet.TryRead(out uint buffDuration); // 4   uint    Buff.Duration
        //
        //     var skill = await Cache.GetRefSkillAsync((int)buffRefSkillId);
        //     if (skill == null) continue;
        //
        //     if (skill.ParamsContains(1701213281))
        //         //1701213281 -> atfe -> "auto transfer effect" like Recovery Division
        //         _packet.TryRead(out bool isCreator); // 1   bool    IsCreator
        // }
        State = State.FromPacket(_packet);

        _packet.TryRead(out CharName); // 2   ushort  Name.Length // *   string  Name
        _packet.TryRead(out JobName); // 2   ushort  JobName.Length // *   string  JobName
        _packet.TryRead(out JobType); // 1   byte    JobType
        _packet.TryRead(out JobLevel); // 1   byte    JobLevel
        _packet.TryRead(out JobExp); // 4   uint    JobExp
        _packet.TryRead(out JobContribution); // 4   uint    JobContribution
        _packet.TryRead(out JobReward); // 4   uint    JobReward
        _packet.TryRead(out PvpState); // 1   byte    PVPState                //0 = White, 1 = Purple, 2 = Red
        _packet.TryRead(out TransportFlag); // 1   byte    TransportFlag
        _packet.TryRead(out InCombat); // 1   byte    InCombat
        if (TransportFlag) _packet.TryRead(out TransportUniqueId); // 4   uint    Transport.UniqueID

        _packet.TryRead(out PvpFlag); // 1   byte    PVPFlag                 //0 = Red Side, 1 = Blue Side, 0xFF = None
        _packet.TryRead(out GuideFlag); // 8   ulong   GuideFlag
        _packet.TryRead(out Jid); // 4   uint    JID
        _packet.TryRead(out GmFlag); // 1   byte    GMFlag

        #endregion

        #region Hotkey

        _packet.TryRead(
            out byte activationFlag); // 1   byte    ActivationFlag          //ConfigType:0 --> (0 = Not activated, 7 = activated)
        _packet.TryRead(out byte hotkeyCount); // 1   byte    Hotkeys.Count           //ConfigType:1
        for (var i = 0; i < hotkeyCount; i++)
        {
            _packet.TryRead(out byte hotkeySlotSeq); // 1   byte    hotkey.SlotSeq
            _packet.TryRead(out byte hotkeySlotContentType); // 1   byte    hotkey.SlotContentType
            _packet.TryRead(out uint hotkeySlotData); // 4   uint    hotkey.SlotData
        }

        #endregion

        #region Autopot

        _packet.TryRead(out ushort autoHpConfig); // 2   ushort  AutoHPConfig            //ConfigType:11
        _packet.TryRead(out ushort autoMpConfig); // 2   ushort  AutoMPConfig            //ConfigType:12
        _packet.TryRead(out ushort autoUniversalConfig); // 2   ushort  AutoUniversalConfig     //ConfigType:13
        _packet.TryRead(out byte autoPotionDelay); // 1   byte    AutoPotionDelay         //ConfigType:14

        #endregion

        #region Whisper

        _packet.TryRead(out byte blockedWhisperCount); // 1   byte    blockedWhisperCount
        for (var i = 0; i < blockedWhisperCount; i++)
            _packet.TryRead(out var target); // 2   ushort  Target.Length // *   string  Target

        #endregion

        _packet.TryRead(out uint unkUshort0); // 4   uint    unkUShort0      //Structure changes!!!
        _packet.TryRead(out byte unkByte4); // 1   byte    unkByte4        //Structure changes!!!
        if (_debug)
        {
            watch.Stop();
            double ticks = watch.ElapsedTicks;
            var seconds = ticks / Stopwatch.Frequency;
            var milliseconds = ticks / Stopwatch.Frequency * 1000;
            var nanoseconds = ticks / Stopwatch.Frequency * 1000000000;
            Log.Information("CharInfo Read: {0}ms", milliseconds);
        }
    }

    public void Clear()
    {
        _packet = null;
    }

    public Packet? GetPacket()
    {
        return _packet;
    }
}