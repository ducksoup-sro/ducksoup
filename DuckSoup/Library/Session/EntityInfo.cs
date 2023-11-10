using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Database.VSRO188;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

// Credits: Mostly taken from RSBot https://github.com/SDClowen/RSBot/
public class EntityInfo
{
    private SpawnInfoType? _spawnInfoType;
    private ushort _amount;
    private bool _single;
    private Packet? _packet = null;
    private bool _exit = false;
    private bool _debug = false;

    public void Initialize(SpawnInfoType spawnInfoType, ushort amount, ushort msgId)
    {
        _packet = new Packet(msgId);
        _spawnInfoType = spawnInfoType;
        _amount = amount;
        if (msgId == 0x3015)
        {
            _single = true;
        }

        if (msgId == 0x3019)
        {
            _packet.Massive = true;
        }
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
            Log.Information("EntityInfo Append: {0}ms - {1} - {2} ", milliseconds, _spawnInfoType, _amount);
        }
    }

    public async Task ReadDespawn()
    {
        if (_packet == null)
        {
            return;
        }

        _packet.ToReadOnly();
        _packet.TryRead(out uint uniqueId);
    }

    public async Task ReadSpawn()
    {
        if (_packet == null || _exit)
        {
            return;
        }

        if (!_packet._isReadOnly)
        {
            _packet.ToReadOnly();
        }

        _packet.TryRead(out uint refObjId);
        if (refObjId == uint.MaxValue)
        {
            return;
        }

        var refObjCommon = await Cache.GetRefObjCommonAsync((int)refObjId);
        if (refObjCommon == null)
        {
            _exit = true;
            return;
        }

        try
        {
            bool hasJobItem = false;
            if (refObjCommon.TypeID1 == 1)
            {
                //BIONIC:
                //  CHARACTER
                //  NPC
                //      NPC_FORTRESS_STRUCT
                //      NPC_MOB
                //      NPC_COS
                //      NPC_FORTRESS_COS    

                if (refObjCommon.TypeID2 == 1)
                {
                    //CHARACTER
                    _packet.TryRead(out byte Character_Scale)
                        .TryRead(out byte Character_HwanLevel)
                        .TryRead(out byte Character_PVPCape)
                        .TryRead(out byte Character_AutoInverstExp);


                    //Inventory
                    _packet.TryRead(out byte Character_Inventory_Size)
                        .TryRead(out byte itemCount);
                    for (int i = 0; i < itemCount; i++)
                    {
                        _packet.TryRead(out uint Item_RefItemId);
                        var item = Cache.GetRefObjCommonAsync((int)Item_RefItemId).Result;
                        if (item.TypeID1 == 3 && item.TypeID2 == 1)
                        {
                            _packet.TryRead(out byte Item_OptLevel);
                        }
                        
                        if (item.TypeID2 == 1 && item.TypeID3 == 7 && item.TypeID4 is not 4 or 5) {
                            hasJobItem = true;
                        }
                    }

                    //AvatarInventory
                    _packet.TryRead(out byte Character_AvatarInventory_Size)
                        .TryRead(out itemCount);
                    for (int i = 0; i < itemCount; i++)
                    {
                        _packet.TryRead(out uint AvatarItem_RefItemId);
                        var item = Cache.GetRefObjCommonAsync((int)AvatarItem_RefItemId).Result;
                        if (item.TypeID1 == 3 && item.TypeID2 == 1)
                        {
                            _packet.TryRead(out byte AvatarItem_OptLevel);
                        }
                    }

                    //Mask
                    _packet.TryRead(out bool hasMask);
                    if (hasMask)
                    {
                        _packet.TryRead(out uint Mask_RefObjId);
                        var maskObject = await Cache.GetRefObjCommonAsync((int)Mask_RefObjId);
                        if (maskObject.TypeID1 == refObjCommon.TypeID1 &&
                            maskObject.TypeID2 == refObjCommon.TypeID2)
                        {
                            _packet.TryRead(out byte Mask_Scale);
                            _packet.TryRead(out byte Mask_ItemCount);
                            //Duplicate
                            for (int i = 0; i < Mask_ItemCount; i++)
                            {
                                _packet.TryRead(out uint MaskItem_RefItemId);
                            }
                        }
                    }
                }
                else if (refObjCommon.TypeID2 == 2 && refObjCommon.TypeID3 == 5)
                {
                    //NPC_FORTRESS_STRUCT
                    _packet.TryRead(out uint FortressStructure_HP)
                        .TryRead(out uint FortressStructure_RefEventStructId)
                        .TryRead(out ushort FortressStructure_State);
                }

                // Is this base? Entity / Bionic?
                _packet.TryRead(out uint Base_UniqueId);

                //Position
                _packet.TryRead(out ushort Base_Position_RegionId)
                    .TryRead(out float Base_Position_X)
                    .TryRead(out float Base_Position_Y)
                    .TryRead(out float Base_Position_Z)
                    .TryRead(out ushort Base_Position_Angle);

                //Movement
                _packet.TryRead(out bool Base_Movement_HasDestination);
                _packet.TryRead(out byte Base_Movement_Type); //0 = Walk, 1 = Run
                if (Base_Movement_HasDestination)
                {
                    //MD (Mouse destination)
                    _packet.TryRead(out ushort Base_Movement_DestinationRegion);
                    if (Base_Position_RegionId < short.MaxValue)
                    {
                        //World
                        _packet.TryRead(out ushort Base_Movement_DestinationOffsetX);
                        _packet.TryRead(out ushort Base_Movement_DestinationOffsetY);
                        _packet.TryRead(out ushort Base_Movement_DestinationOffsetZ);
                    }
                    else
                    {
                        //Dungeon
                        _packet.TryRead(out uint Base_Movement_DestinationOffsetX);
                        _packet.TryRead(out uint Base_Movement_DestinationOffsetY);
                        _packet.TryRead(out uint Base_Movement_DestinationOffsetZ);
                    }
                }
                else
                {
                    _packet.TryRead(out byte Base_Movement_Source); //0 = Spinning, 1 = Sky-/Key-walking
                    _packet.TryRead(out ushort Base_Movement_Angle); //Represents the new angle, character is looking at
                }

                //State
                _packet.TryRead(out LifeState Base_State_LifeState); // byte
                _packet.TryRead(out byte Base_State_unkByte0); 
                _packet.TryRead(out MotionState Base_State_MotionState); // byte
                _packet.TryRead(out BodyState Base_State_BodyState); // byte
                _packet.TryRead(out float Bionic_State_WalkSpeed);
                _packet.TryRead(out float Bionic_State_RunSpeed);
                _packet.TryRead(out float Bionic_State_HwanSpeed);
                _packet.TryRead(out byte Bionic_State_BuffCount);
                for (int i = 0; i < Bionic_State_BuffCount; i++)
                {
                    _packet.TryRead(out uint Buff_RefSkillID);
                    _packet.TryRead(out uint Buff_Duration);
                    var skill = await Cache.GetRefSkillAsync((int)Buff_RefSkillID);
                    if (skill.ParamsContains(1701213281))
                    {
                        //1701213281 -> atfe -> "auto transfer effect" like Recovery Division
                        _packet.TryRead(out bool Buff_IsCreator);
                    }
                }

                if (refObjCommon.TypeID2 == 1)
                {
                    //CHARACTER
                    _packet.TryRead(out ushort Character_Name);

                    _packet.TryRead(out Job Character_JobType); // byte
                    _packet.TryRead(out byte Character_JobLevel);
                    _packet.TryRead(out PvpState Character_PVPState); // byte
                    _packet.TryRead(out bool Character_IsRiding);
                    _packet.TryRead(out byte Character_InCombat);
                    if (Character_IsRiding)
                    {
                        _packet.TryRead(out uint Transport_UniqueID);
                    }

                    _packet.TryRead(out ScrollState Character_ScrollMode); // byte
                    _packet.TryRead(out InteractMode Character_InteractMode); // byte
                    _packet.TryRead(out byte Character_unkByte4);

                    //Guild
                    _packet.TryRead(out string Character_Guild_Name);
                    if (!hasJobItem)
                    {
                        _packet.TryRead(out uint Character_Guild_ID);
                        _packet.TryRead(out string Character_GuildMember_Nickname);
                        _packet.TryRead(out uint Character_Guild_LastCrestRev);
                        _packet.TryRead(out uint Character_Union_ID);
                        _packet.TryRead(out uint Character_Union_LastCrestRev);
                        _packet.TryRead(out byte Character_Guild_IsFriendly); //0 = Hostile, 1 = Friendly
                        _packet.TryRead(out FortSiegeAuthority Character_GuildMember_SiegeAuthority); // byte
                    }

                    if (Character_InteractMode == InteractMode.P2N_TALK) //P2N_TALK
                    {
                        _packet.TryRead(out string Character_Stall_Name);
                        _packet.TryRead(out uint Character_Stall_RefItemID); //Decoration
                    }

                    _packet.TryRead(out byte Character_EquipmentCooldown);
                    _packet.TryRead(out byte Character_PKFlag);
                }
                else if (refObjCommon.TypeID2 == 2)
                {
                    //NPC        
                    _packet.TryRead(out byte NPC_TalkFlag);
                    if (NPC_TalkFlag == 2)
                    {
                        _packet.TryRead(out byte NPC_TalkOptionCount);
                        for (int i = 0; i < NPC_TalkOptionCount; i++)
                        {
                            _packet.TryRead(out byte NPC_TalkOptions); // * byte[] TalkOptions
                        }
                    }

                    if (refObjCommon.TypeID3 == 1)
                    {
                        //NPC_MOB
                        _packet.TryRead(out MonsterRarity Monster_Rarity); // byte
                        if (refObjCommon.TypeID4 == 2 || refObjCommon.TypeID4 == 3)
                        {
                            _packet.TryRead(out byte Monster_Appearance); //Randomized by server. Monsters only have one appearance. Thieves / Hunters don't, perhaps Thief/Hunter?
                        }
                    }
                    else if (refObjCommon.TypeID3 == 3)
                    {
                        //NPC_COS
                        // CodeName128 = NPC_COS_TRANSPORT
                        // CodeName128 = NPC_COS_P_GROWTH
                        // CodeName128 = NPC_COS_P_ABILITY
                        // CodeName128 = NPC_COS_GUILD
                        // CodeName128 = NPC_COS_CAPTURED
                        // CodeName128 = NPC_COS_QUEST
                        // CodeName128 = NPC_COS_QUEST
                        if (refObjCommon.TypeID4 == 2 || 
                            refObjCommon.TypeID4 == 3 || 
                            refObjCommon.TypeID4 == 4 || 
                            refObjCommon.TypeID4 == 5 || 
                            refObjCommon.TypeID4 == 6 || 
                            refObjCommon.TypeID4 == 7 || 
                            refObjCommon.TypeID4 == 8) 
                        {
                            if (refObjCommon.TypeID4 == 3 ||
                                refObjCommon.TypeID4 == 4)
                            {
                                // NPC_COS_P (Growth)
                                // NPC_COS_P (Ability)
                                _packet.TryRead(out string COS_Name);
                            }
                            else if (refObjCommon.TypeID4 == 5)
                            {
                                //NPC_COS_GUILD
                                _packet.TryRead(out string COS_Guild_Name);
                            }

                            if (refObjCommon.TypeID4 == 2 || //NPC_COS_T
                                refObjCommon.TypeID4 == 3 || //NPC_COS_P (Growth)
                                refObjCommon.TypeID4 == 4 || //NPC_COS_P (Ability)
                                refObjCommon.TypeID4 == 5 || //NPC_COS_GUILD
                                refObjCommon.TypeID4 == 6)
                            {
                                // --Fixes Start, Thanks @BimBum
                                _packet.TryRead(out string COS_Owner_Name);

                                if (refObjCommon.TypeID4 == 2 ||
                                    refObjCommon.TypeID4 == 3 ||
                                    refObjCommon.TypeID4 == 4 ||
                                    refObjCommon.TypeID4 == 5)
                                {
                                    _packet.TryRead(out byte COS_Owner_JobType);

                                    if (refObjCommon.TypeID4 == 2 ||
                                        refObjCommon.TypeID4 == 3 ||
                                        refObjCommon.TypeID4 == 5)
                                    {
                                        _packet.TryRead(out byte COS_Owner_PVPState);
                                        if (refObjCommon.TypeID4 == 5) 
                                        {
                                            //NPC_COS_GUILD
                                            _packet.TryRead(out uint COS_Owner_RefObjID);
                                        }
                                    }
                                }
                            }
                            // --Fixes End
                            _packet.TryRead(out uint COS_Owner_UniqueID);
                        }
                    }
                    else if (refObjCommon.TypeID3 == 4)
                    {
                        //NPC_FORTRESS_COS            
                        _packet.TryRead(out uint COS_Guild_ID);
                        _packet.TryRead(out string COS_Guild_Name);
                    }
                }
            }
            else if (refObjCommon.TypeID1 == 3)
            {
                //ITEM:
                //  ITEM_EQUIP
                //  ITEM_ETC
                //      ITEM_ETC_MONEY_GOLD
                //      ITEM_ETC_TRADE
                //      ITEM_ETC_QUEST    

                if (refObjCommon.TypeID2 == 1)
                {
                    //ITEM_EQUIP        
                    _packet.TryRead(out byte Item_OptLevel);
                }
                else if (refObjCommon.TypeID2 == 3)
                {
                    //ITEM_ETC        
                    if (refObjCommon.TypeID3 == 5 && refObjCommon.TypeID4 == 0)
                    {
                        //ITEM_ETC_MONEY_GOLD
                        _packet.TryRead(out uint Amount);
                    }
                    else if (refObjCommon.TypeID3 == 8 || refObjCommon.TypeID3 == 9)
                    {
                        //ITEM_ETC_TRADE
                        //ITEM_ETC_QUEST
                        _packet.TryRead(out string Item_Owner_Name);
                    }
                }

                _packet.TryRead(out uint Item_UniqueID);
                _packet.TryRead(out ushort Item_Position_RegionID);
                _packet.TryRead(out float Item_Position_X);
                _packet.TryRead(out float Item_Position_Y);
                _packet.TryRead(out float Item_Position_Z);
                _packet.TryRead(out ushort Item_Position_Angle); // The angle how its rotated on the floor?
                _packet.TryRead(out bool Item_hasOwner);
                if (Item_hasOwner)
                {
                    _packet.TryRead(out uint Item_Owner_JID);
                }

                _packet.TryRead(out byte Item_Rarity);
            }
            else if (refObjCommon.TypeID1 == 4)
            {
                //PORTALS:
                //  STORE
                //  INS_TELEPORTER

                _packet.TryRead(out uint Portal_UniqueID);
                _packet.TryRead(out ushort Portal_Position_RegionID);
                _packet.TryRead(out float Portal_Position_X);
                _packet.TryRead(out float Portal_Position_Y);
                _packet.TryRead(out float Portal_Position_Z);
                _packet.TryRead(out ushort Portal_Position_Angle);

                _packet.TryRead(out byte Portal_unkByte0);
                _packet.TryRead(out byte Portal_unkByte1);
                _packet.TryRead(out byte Portal_unkByte2);
                _packet.TryRead(out byte Portal_unkByte3);
                if (Portal_unkByte3 == 1)
                {
                    //Regular
                    _packet.TryRead(out uint unkUInt0);
                    _packet.TryRead(out uint unkUInt1);
                }
                else if (Portal_unkByte3 == 6)
                {
                    //Dimension Hole
                    _packet.TryRead(out string Portal_Owner_Name);
                    _packet.TryRead(out uint Portal_Owner_UniqueID);
                }

                if (Portal_unkByte3 == 1)
                {
                    //STORE_EVENTZONE_DEFAULT
                    _packet.TryRead(out uint unkUInt3);
                    _packet.TryRead(out byte unkByte5);
                }
            }
            else if (refObjId == uint.MaxValue)
            {
                //EVENT_ZONE (Traps, Buffzones, ...)
                _packet.TryRead(out ushort EventZone_unkUShort0);
                _packet.TryRead(out uint EventZone_RefSkillID);
                _packet.TryRead(out uint EventZone_UniqueID);
                _packet.TryRead(out ushort EventZone_Position_RegionID);
                _packet.TryRead(out float EventZone_Position_X);
                _packet.TryRead(out float EventZone_Position_Y);
                _packet.TryRead(out float EventZone_Position_Z);
                _packet.TryRead(out ushort EventZone_Position_Angle);
            }

            if (_packet.MsgId == 0x3015)
            {
                if (refObjCommon.TypeID1 == 1 || refObjCommon.TypeID1 == 4)
                {
                    _packet.TryRead(out byte spawnType); // 1 = Normal, 3 = Spawning, 4 = Running
                }
                else if (refObjCommon.TypeID1 == 3)
                {
                    _packet.TryRead(out byte dropSource)
                        .TryRead(out uint dropperUniqueId);
                }
            }
        }
        catch (Exception e)
        {
            Log.Error("EntityParse Error: {0} \n{1}", e.Message, e.StackTrace);
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

        for (var i = 0; i < _amount; i++)
        {
            if (_exit)
            {
                break;
            }

            switch (_spawnInfoType)
            {
                case SpawnInfoType.Spawn: //Spawn
                    await ReadSpawn();
                    break;
                case SpawnInfoType.Despawn: //Despawn
                    await ReadDespawn();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (_debug)
        {
            watch.Stop();
            double ticks = watch.ElapsedTicks;
            var seconds = ticks / Stopwatch.Frequency;
            var milliseconds = ticks / Stopwatch.Frequency * 1000;
            var nanoseconds = ticks / Stopwatch.Frequency * 1000000000;
            Log.Information("EntityInfo Read: {0}ms - Early Exit: {1} - Amount: {2} - Type: {3}", milliseconds, _exit,
                _amount, _spawnInfoType);
        }
    }

    public void Clear()
    {
        _packet = null;
        _spawnInfoType = null;
        _amount = 0;
        _exit = false;
    }

    public SpawnInfoType? GetSpawnInfoType()
    {
        return _spawnInfoType;
    }

    public ushort? GetAmount()
    {
        return _amount;
    }

    public Packet? GetPacket()
    {
        return _packet;
    }
}