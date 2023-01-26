#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API;
using API.Database.Context;
using API.Database.DuckSoup;
using API.EventFactory;
using API.Server;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Objects.Cos;
using DuckSoup.Library.Objects.Inventory;
using DuckSoup.Library.Objects.Spawn;
using DuckSoup.Library.Party;
using DuckSoup.Library.Server;
using Microsoft.EntityFrameworkCore;
using PacketLibrary;
using PacketLibrary.Agent.Client;
using SilkroadSecurityAPI;

#endregion

// ReSharper disable UnusedVariable

#pragma warning disable 1998

namespace DuckSoup.Agent;

public class AgentServer : AsyncServer
{
    public AgentServer(Service service) : base(service)
    {
        SharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));

        using (var context = new API.Database.Context.DuckSoup())
        {
            if (!context.Whitelists.Any(s => s.ServerType == ServerType.AgentServer))
            {
                foreach (var (key, value) in DefaultPacketlist.AgentClientWhitelistFull)
                {
                    context.Whitelists.Add(new Whitelist
                        { MsgId = key, Comment = value, ServerType = ServerType.AgentServer });
                }

                context.SaveChanges();
            }

            // Conversion shit because Database actually only supports int not ushort sadge
            var temp1 = context.Whitelists.Where(s => s.ServerType == ServerType.AgentServer).Select(s => s.MsgId)
                .ToList();
            var temp2 = context.Blacklists.Where(s => s.ServerType == ServerType.AgentServer).Select(s => s.MsgId)
                .ToList();
            var temp3 = new HashSet<ushort>();
            var temp4 = new HashSet<ushort>();
            foreach (var i in temp1)
            {
                temp3.Add(ushort.Parse(i.ToString()));
            }

            foreach (var i in temp2)
            {
                temp4.Add(ushort.Parse(i.ToString()));
            }

            PacketHandler = new PacketHandler(temp3, temp4);
        }

        var partyManagerHandlers = new PartyManagerHandlers(PacketHandler);

        // ping
        PacketHandler.RegisterClientHandler(0x2002, async (_, session, _) =>
        {
            session.LastPing = DateTime.Now;
            return new PacketResult();
        });

        // Register all handlers here
        // Mainly Exploits
        PacketHandler.RegisterClientHandler(0x7001,
            AGENT_CHARACTER_SELECTION_JOIN); // charname modify and not really logged in Exploit - 0x7001 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4232366-release-disconnect-players-exploit-found-iwa-4.html 
        PacketHandler.RegisterClientHandler(0x705E,
            AGENT_SIEGE_ACTION); // SQL Injection - 0x705E - Also contains Tax / checkout checks - https://www.elitepvpers.com/forum/sro-private-server/4141360-information-sql-injection-ingame.html
        PacketHandler.RegisterClientHandler(0x70F9,
            AGENT_GUILD_UPDATE_NOTICE); // Guild Notice - 0x70F9 - Better safe than sorry.
        PacketHandler.RegisterClientHandler(0x34A9,
            AGENT_MAGICOPTION_GRANT); // Avatar Exploit - 0x34A9 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/3991992-release-invincible-avatar-magopt-exploit-3.html
        PacketHandler.RegisterClientHandler(0x7005,
            AGENT_LOGOUT); // [x] Crash Exploit - 0x7005 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4232366-release-disconnect-players-exploit-found-iwa.html
        PacketHandler.RegisterClientHandler(0x7007, CLIENT_AGENT_CHARACTER_SELECTION_ACTION_REQUEST); // same as above
        PacketHandler.RegisterClientHandler(0x70A7,
            CLIENT_PLAYER_BERSERK); // Zerk Exploit - 0x70A7 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/3991992-release-invincible-avatar-magopt-exploit-3.html
        PacketHandler.RegisterClientHandler(0x70A2,
            AGENT_SKILL_MASTERY_LEARN); // Skill Exploit - 0x70A2 - https://www.maxigame.com/forum/t/251583-meshur-vsro-mastery-exploit-ini-delirius-engelleme
        PacketHandler.RegisterClientHandler(0x3510,
            CLIENT_EXPLOIT_GSCRASH); // GS Crash Exploit - 0x3510 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4383384-release-fix-gameserver-crash-runtime-error-exploit.html
        PacketHandler.RegisterModuleHandler(0xA103, AGENT_AUTH); // Exploit Prevention

        PacketHandler.RegisterClientHandler(0x7074, CLIENT_CHARACTER_ACTION_REQUEST); // Snow Shield fix

        // Mainly Data / Information
        PacketHandler.RegisterModuleHandler(0x3013, SERVER_AGENT_CHARACTER_DATA); // Character Spawn Packet
        PacketHandler.RegisterModuleHandler(0x30C8, SERVER_AGENT_COS_INFO);
        PacketHandler.RegisterModuleHandler(0x30C9, SERVER_AGENT_COS_UPDATE);
        PacketHandler.RegisterModuleHandler(0xB0CB, SERVER_AGENT_COS_UPDATE_RIDESTATE);
        PacketHandler.RegisterModuleHandler(0xB516, AGENT_FRPVP_UPDATE);

        // Test Stuff
        PacketHandler.RegisterModuleHandler(0x3015, EntitySingleSpawnResponse);
        PacketHandler.RegisterModuleHandler(0x3016, EntitySingleDespawnResponse); // not needed right now
        PacketHandler.RegisterModuleHandler(0x3017, EntityGroupSpawnBeginResponse);
        PacketHandler.RegisterModuleHandler(0x3018, EntityGroupSpawnEndResponse);
        PacketHandler.RegisterModuleHandler(0x3019, EntityGroupSpawnDataResponse);

        PacketHandler.RegisterClientHandler(0x3012, AGENT_GAME_READY); // GameReady true
        PacketHandler.RegisterClientHandler(0x705A, AGENT_TELEPORT_USE); // GameReady false
        PacketHandler.RegisterModuleHandler(0x3020, AGENT_ENVIRONMENT_CELESTIAL_POSITION); // CharacterUniqueId
        PacketHandler.RegisterModuleHandler(0x30BF, SERVER_ENTITY_STATE_UPDATE);
        PacketHandler.RegisterModuleHandler(0xB021, AGENT_MOVEMENT_SERVER);
    }

    private async Task<PacketResult> AGENT_FRPVP_UPDATE(Packet packet, ISession session, PacketData data)
    {
        var result = packet.ReadUInt8(); // 1   byte    result
        if (result == 1)
        {
            var uniqueId = packet.ReadUInt32(); // 4   uint    Player.UniqueID
            var cape = (PVPCape)packet.ReadUInt8(); // 1   byte    Player.FRPVPMode
            if (session.SessionData.UniqueCharId == uniqueId)
            {
                session.SessionData.State.PvpCape = cape;
            }
        }
        else if (result == 2)
        {
            packet.ReadUInt16(); // 2   ushort  errorCode
        }

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_COS_UPDATE_RIDESTATE(Packet packet, ISession session, object obj)
    {
        if (packet.ReadUInt8() != 0x01)
            return new PacketResult();

        var ownerUniqueId = packet.ReadUInt32();
        var isMounted = packet.ReadBool();
        var cosUniqueId = packet.ReadUInt32();

        if (ownerUniqueId == session.SessionData.UniqueCharId)
        {
            if (cosUniqueId == session.SessionData.Transport?.UniqueId)
                session.SessionData.Vehicle = session.SessionData.Transport;

            if (cosUniqueId == session.SessionData.JobTransport?.UniqueId)
                session.SessionData.Vehicle = session.SessionData.JobTransport;

            // Vsro private servers uses the attack pet like pet2
            if (cosUniqueId == session.SessionData.Growth?.UniqueId)
                session.SessionData.Vehicle = session.SessionData.Growth;

            if (cosUniqueId == session.SessionData.Fellow?.UniqueId)
                session.SessionData.Vehicle = session.SessionData.Fellow;

            session.SessionData.OnTransport = isMounted;
            session.SessionData.TransportUniqueId = cosUniqueId;

            if (!isMounted)
            {
                session.SessionData.Vehicle = null;
                session.SessionData.Transport = null;
                session.SessionData.TransportUniqueId = 0;
            }
        }


        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_COS_UPDATE(Packet packet, ISession session, object obj)
    {
        var uniqueId = packet.ReadUInt32();
        ;
        var type = packet.ReadUInt8();
        var refLevel = SharedObjects.RefLevel;

        if (session.SessionData.Growth?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.SessionData.Growth = null;
                    break;
                case 2: // update inventory
                    break;
                case 3:
                    var experience = packet.ReadInt64();
                    var source = packet.ReadUInt32();
                    ;
                    if (source == session.SessionData.Growth.UniqueId)
                        return new PacketResult();

                    session.SessionData.Growth.Experience += experience;

                    var iLevel = session.SessionData.Growth.Level;
                    while (session.SessionData.Growth.Experience > refLevel.First(c => c.Key == iLevel).Value.Exp_C)
                    {
                        session.SessionData.Growth.Experience -= refLevel.First(c => c.Key == iLevel).Value.Exp_C;
                        iLevel++;
                    }

                    if (session.SessionData.Growth.Level < iLevel)
                    {
                        session.SessionData.Growth.Level = iLevel;
                    }

                    break;
                case 4:
                    session.SessionData.Growth.CurrentHungerPoints = packet.ReadUInt16();
                    break;
                case 5:
                    session.SessionData.Growth.Name = packet.ReadAscii();
                    break;
                case 7:
                    session.SessionData.Growth.Id = packet.ReadUInt32();
                    ;
                    var record = session.SessionData.Growth.RefObjChar;
                    if (record != null)
                        session.SessionData.Growth.Health = session.SessionData.Growth.MaxHealth = record.MaxHP;
                    break;
                default:
                    break;
            }
        }
        else if (session.SessionData.Fellow?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.SessionData.Fellow = null;
                    break;
                case 2: // update inventory
                    break;
                case 3:
                    var experience = packet.ReadInt64();
                    var source = packet.ReadUInt32();
                    ;
                    if (source == session.SessionData.Fellow.UniqueId)
                        return new PacketResult();

                    session.SessionData.Fellow.Experience += experience;

                    var iLevel = session.SessionData.Fellow.Level;
                    while (session.SessionData.Fellow.Experience > refLevel.First(c => c.Key == iLevel).Value.Exp_C)
                    {
                        session.SessionData.Fellow.Experience -= refLevel.First(c => c.Key == iLevel).Value.Exp_C;
                        iLevel++;
                    }

                    if (session.SessionData.Fellow.Level < iLevel)
                    {
                        session.SessionData.Fellow.Level = iLevel;
                        session.SessionData.Fellow.MaxHealth = session.SessionData.Fellow.Health;
                    }

                    break;
                case 4:
                    session.SessionData.Fellow.Satiety = packet.ReadUInt16();
                    break;
                case 5:
                    session.SessionData.Fellow.Name = packet.ReadAscii();
                    break;
                case 7:
                    session.SessionData.Fellow.Id = packet.ReadUInt32();
                    ;
                    var record = session.SessionData.Fellow.RefObjChar;
                    if (record != null)
                        session.SessionData.Fellow.Health = session.SessionData.Fellow.MaxHealth = record.MaxHP;
                    break;
                default:
                    break;
            }
        }
        else if (session.SessionData.AbilityPet?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.SessionData.AbilityPet = null;
                    break;
                case 2:
                    session.SessionData.AbilityPet.Inventory.Deserialize(packet);
                    break;
                case 5:
                    session.SessionData.AbilityPet.Name = packet.ReadAscii();
                    break;
            }
        }
        else if (session.SessionData.Transport?.UniqueId == uniqueId)
        {
            session.SessionData.Transport = null;
        }
        else if (session.SessionData.JobTransport?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.SessionData.JobTransport = null;
                    break;
                case 2:
                    session.SessionData.JobTransport.Inventory.Deserialize(packet);
                    break;
            }
        }

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_COS_INFO(Packet packet, ISession session, object obj)
    {
        var uniqueId = packet.ReadUInt32();
        var objectId = packet.ReadUInt32();

        var objCommon = SharedObjects.RefObjCommon.First(c => c.Value.ID == objectId).Value;
        var objChar = SharedObjects.RefObjChar.First(c => c.Value.ID == objCommon.Link).Value;
        if (objCommon.TypeID2 == 2 && objCommon.TypeID3 == 3)
        {
            var hp = packet.ReadInt32();
            var maxHp = packet.ReadInt32();
            maxHp = maxHp != 0 && maxHp != 200 ? maxHp : objChar.MaxHP;

            switch (objCommon.TypeID4)
            {
                case 1:
                    session.SessionData.Transport = new Transport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    break;
                case 2:
                    session.SessionData.JobTransport = new JobTransport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                        Inventory = new InventoryItemCollection(packet),
                        OwnerUniqueId = packet.ReadUInt32()
                    };
                    break;
                case 3:
                    session.SessionData.Growth = new Growth
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    session.SessionData.Growth.Deserialize(packet);
                    break;
                case 4:
                    session.SessionData.AbilityPet = new Ability
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    session.SessionData.AbilityPet.Deserialize(packet);
                    break;
                case 9:
                    session.SessionData.Fellow = new Fellow
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    session.SessionData.Fellow.Deserialize(packet);
                    break;
            }
        }

        return new PacketResult();
    }

    private async Task<PacketResult> EntitySingleDespawnResponse(Packet packet, ISession session, object obj)
    {
        var uniqueId = packet.ReadUInt32();
        return new PacketResult();
    }

    private async Task<PacketResult> EntityGroupSpawnEndResponse(Packet packet, ISession session, object obj)
    {
        var pck = session.SpawnInfo.GetPacket();
        pck.ToReadOnly();

        for (var i = 0; i < session.SpawnInfo.GetAmount(); i++)
        {
            switch (session.SpawnInfo.GetSpawnInfoType())
            {
                case SpawnInfoType.Spawn: //Spawn
                    ParseSpawn(session, pck, true);
                    break;
                case SpawnInfoType.Despawn: //Despawn
                    var uniqueId = pck.ReadUInt32();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        session.SpawnInfo.Clear();
        return new PacketResult();
    }

    private async Task<PacketResult> EntitySingleSpawnResponse(Packet packet, ISession session, object obj)
    {
        ParseSpawn(session, packet);
        return new PacketResult();
    }

    private async Task<PacketResult> EntityGroupSpawnDataResponse(Packet packet, ISession session, object obj)
    {
        if (session.SpawnInfo.GetSpawnInfoType() == null || session.SpawnInfo.GetAmount() == null ||
            session.SpawnInfo.GetPacket() == null)
        {
            return new PacketResult();
        }

        session.SpawnInfo.GetPacket()?.WriteUInt8Array(packet.GetBytes());

        return new PacketResult();
    }

    private async Task<PacketResult> EntityGroupSpawnBeginResponse(Packet packet, ISession session, object obj)
    {
        session.SpawnInfo.Read(packet);
        return new PacketResult();
    }

    public void ParseSpawn(ISession session, Packet packet, bool isGroup = false)
    {
        // Credits: Mostly taken from RSBot https://github.com/SDClowen/RSBot/
        var refObjId = packet.ReadUInt32();

        if (refObjId == uint.MaxValue)
        {
            return;
        }

        // ghidra(isro client): FUN_009dd970 maybe flowers?
        if (refObjId == 0xfffffffe)
        {
            packet.ReadUInt32();
            packet.ReadUInt32();
        }

        var obj = SharedObjects.RefObjCommon[(int)refObjId];

        if (obj == null)
        {
            return;
        }

        switch (obj.TypeID1)
        {
            case 1:
                switch (obj.TypeID2)
                {
                    case 1:
                    {
                        var spawnedPlayer = new SpawnedPlayer(refObjId);
                        spawnedPlayer.Deserialize(packet);
                        var spawnedPlayerSession = SharedObjects.AgentSessions.FirstOrDefault(c =>
                            c.SessionData.UniqueCharId == spawnedPlayer.UniqueId);
                        if (spawnedPlayerSession == null)
                        {
                            break;
                        }

                        if (spawnedPlayerSession.TimerManager.IsStarted() &&
                            spawnedPlayerSession.TimerManager.IsBroadcast())
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(100);
                                spawnedPlayerSession.TimerManager.Send(session);
                            });
                        }
                    }
                        break;
                    case 2:
                        switch (obj.TypeID3)
                        {
                            case 1:
                            {
                                var spawnedMonster = new SpawnedMonster(refObjId);
                                spawnedMonster.Deserialize(packet);
                            }
                                break;
                            case 3:
                            {
                                var spawnedCos = new SpawnedCos(refObjId);
                                spawnedCos.Deserialize(packet);
                            }
                                break;
                            case 4:
                            {
                                var guildId = packet.ReadUInt32();
                                var guildName = packet.ReadAscii();
                                break;
                            }
                            case 5:
                            {
                                var spawnedFortressStructure = new SpawnedFortressStructure(refObjId);
                                spawnedFortressStructure.Deserialize(packet);
                            }
                                break;

                            default:
                            {
                                var spawnedNpc = new SpawnedNpcNpc(refObjId);
                                spawnedNpc.ParseBionicDetails(packet);
                                spawnedNpc.Deserialize(packet);
                            }
                                break;
                        }

                        break;
                }

                break;
            case 3:
                var spawnedItem = SpawnedItem.FromPacket(packet, refObjId);
                break;

            case 4:
                var spawnedPortal = SpawnedPortal.FromPacket(packet, refObjId);
                break;
        }

        if (!isGroup)
        {
            if (obj.TypeID1 == 1 || obj.TypeID1 == 4)
            {
                packet.ReadUInt8(); // 1 = Normal, 3 = Spawning, 4 = Running
            }
            else if (obj.TypeID1 == 3)
            {
                packet.ReadUInt8(); // DropSource
                packet.ReadUInt32(); // DropUID
            }
        }
    }

    private ISharedObjects SharedObjects { get; set; }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        SharedObjects.AgentSessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        if (SharedObjects.AgentSessions.Contains(session)) SharedObjects.AgentSessions.Remove(session);

        //CustomTitles?.RemoveSession(session);
    }

    public override void Dispose()
    {
        if (SharedObjects != null)
        {
            foreach (var agentSession in SharedObjects.AgentSessions)
            {
                agentSession.Stop();
            }
        }

        SharedObjects = null;

        base.Dispose();
    }

    private async Task<PacketResult> CLIENT_CHARACTER_ACTION_REQUEST(Packet packet, ISession session, object obj)
    {
        var unk1 = packet.ReadUInt8();
        if (unk1 != 0x01) return new PacketResult();

        var action = (CharacterAction)packet.ReadUInt8();
        if (action != CharacterAction.SkillCast) return new PacketResult();

        var skillId = (int)packet.ReadUInt32();
        var skill = SharedObjects.RefSkill.GetValueOrDefault(skillId, null);
        if (skill == null) return new PacketResult();

        if (!skill.Basic_Code.Contains("COLD_SHIELD")) return new PacketResult();

        if (session.SessionData.LastSnowshieldUsage + skill.Action_ReuseDelay >
            DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        {
            session.SendNotice("You cannot use Snow Shield again. Please wait another " +
                               (int)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() -
                                      session.SessionData.LastSnowshieldUsage - skill.Action_ReuseDelay) / 1000 *
                                     -1) + " seconds!");
            return new PacketResult(PacketResultType.Block);
        }

        session.SessionData.LastSnowshieldUsage = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_ENTITY_STATE_UPDATE(Packet packet, ISession session, object obj)
    {
        var uniqueId = packet.ReadUInt32();
        if (session.SessionData.UniqueCharId != uniqueId) return new PacketResult();

        var updateType = packet.ReadUInt8();
        var updateState = packet.ReadUInt8();

        switch (updateType)
        {
            case 0:
                session.SessionData.State.LifeState = (LifeState)updateState;
                if ((LifeState)updateState == LifeState.Dead && session.CountdownManager.IsStopOnDead() &&
                    session.CountdownManager.IsStarted())
                {
                    session.CountdownManager.Stop();
                }

                if (session.TimerManager.IsStarted())
                {
                    session.TimerManager.Stop();
                }

                break;
            case 1:
                var motionState = (MotionState)updateState;
                session.SessionData.State.MotionState = motionState;

                session.SessionData.State.MovementType = motionState switch
                {
                    MotionState.Walking => MovementType.Walking,
                    MotionState.Running => MovementType.Running,
                    MotionState.StandUp => MovementType.None,
                    MotionState.Sitting => MovementType.None,
                    _ => throw new ArgumentOutOfRangeException()
                };

                break;
            case 4:
                session.SessionData.State.BodyState = (BodyState)updateState;
                break;

            case 7:
                session.SessionData.State.PvpState = (PvpState)updateState;
                break;
            case 8:
                session.SessionData.State.BattleState = (BattleState)updateState;
                if ((BattleState)updateState == BattleState.InBattle && session.TimerManager.IsStarted() &&
                    session.TimerManager.IsStopOnBattle())
                {
                    session.TimerManager.Stop();
                }

                break;
            case 11:
                session.SessionData.State.ScrollState = (ScrollState)updateState;
                break;

            default:
                Global.Logger.ErrorFormat("{0} - EntityUpdate: Unknown update type {1} - State: {2}",
                    session.SessionData.Charname, updateType, updateState);
                break;
        }

        return new PacketResult();
    }

    private async Task<PacketResult> SERVER_AGENT_CHARACTER_DATA(Packet packet, ISession session, object obj)
    {
        var serverTime = packet.ReadUInt32(); // * 4   uint    ServerTime               //SROTimeStamp
        var refObjId = packet.ReadUInt32(); // 4   uint    RefObjID
        var scale = packet.ReadUInt8(); // 1   byte    Scale
        var curLevel = packet.ReadUInt8(); // 1   byte    CurLevel
        var maxLevel = packet.ReadUInt8(); // 1   byte    MaxLevel
        var expOffset = packet.ReadUInt64(); // 8   ulong   ExpOffset
        var sExpOffset = packet.ReadUInt32(); // 4   uint    SExpOffset
        var remainGold = packet.ReadUInt64(); // 8   ulong   RemainGold
        var remainSkillPoint = packet.ReadUInt32(); // 4   uint    RemainSkillPoint
        var remainStatPoint = packet.ReadUInt16(); // 2   ushort  RemainStatPoint
        var remainHwanCount = packet.ReadUInt8(); // 1   byte    RemainHwanCount
        var gatheredExpPoint = packet.ReadUInt32(); // 4   uint    GatheredExpPoint
        var hp = packet.ReadUInt32(); // 4   uint    HP
        var mp = packet.ReadUInt32(); // 4   uint    MP
        var autoInverstExp = packet.ReadUInt8(); // 1   byte    AutoInverstExp
        var dailyPk = packet.ReadUInt8(); // 1   byte    DailyPK
        var totalPk = packet.ReadUInt16(); // 2   ushort  TotalPK
        var pkPenaltyPoint = packet.ReadUInt32(); // 4   uint    PKPenaltyPoint
        var hwanLevel = packet.ReadUInt8(); // 1   byte    HwanLevel
        session.SessionData.State.PvpCape =
            (PVPCape)packet
                .ReadUInt8(); // 1   byte    FreePVP           //0 = None, 1 = Red, 2 = Gray, 3 = Blue, 4 = White, 5 = Gold

        // //Inventory
        var inventorySize = packet.ReadUInt8(); // 1   byte    Inventory.Size
        var inventoryItemCount = packet.ReadUInt8(); // 1   byte    Inventory.ItemCount
        for (var i = 0; i < inventoryItemCount; i++) // for (int i = 0; i < Inventory.ItemCount; i++)
        {
            var itemSlot = packet.ReadUInt8(); //     1   byte    item.Slot
            var itemRentType = packet.ReadUInt32(); //     4   uint    item.RentType
            if (itemRentType == 1)
            {
                var itemRentInfoCanDelete = packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoPeriodBeginTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodBeginTime
                var itemRentInfoPeriodEndTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodEndTime        
            }
            else if (itemRentType == 2)
            {
                var itemRentInfoCanDelete = packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoCanRecharge = packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanRecharge
                var itemRentInfoMeterRateTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.MeterRateTime        
            }
            else if (itemRentType == 3)
            {
                var itemRentInfoCanDelete = packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanDelete
                var itemRentInfoCanRecharge = packet.ReadUInt16(); //         2   ushort  item.RentInfo.CanRecharge
                var itemRentInfoPeriodBeginTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodBeginTime
                var itemRentInfoPeriodEndTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.PeriodEndTime   
                var itemRentInfoPackingTime =
                    packet.ReadUInt32(); //         4   uint    item.RentInfo.PackingTime        
            }

            var itemRefItemId = packet.ReadUInt32(); //     4   uint    item.RefItemID
            var item = SharedObjects.RefObjCommon[(int)itemRefItemId];

            if (item == null) continue;
            if (item.TypeID1 == 3)
            {
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    var itemOptLevel = packet.ReadUInt8(); // 1   byte    item.OptLevel
                    var itemVariance = packet.ReadUInt64(); // 8   ulong   item.Variance
                    var itemData = packet.ReadUInt32(); // 4   uint    item.Data       //Durability
                    var itemMagParamNum = packet.ReadUInt8(); // 1   byte    item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        var magParamType = packet.ReadUInt32(); // 4   uint    magParam.Type
                        var magParamValue = packet.ReadUInt32(); // 4   uint    magParam.Value                
                    }

                    var bindingOptionType = packet.ReadUInt8(); // 1   byte    bindingOptionType   //1 = Socket
                    var bindingOptionCount = packet.ReadUInt8(); // 1   byte    bindingOptionCount
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount; bindingOptionIndex++)
                    {
                        var bindingOptionSlot = packet.ReadUInt8(); // 1   byte bindingOption.Slot
                        var bindingOptionId = packet.ReadUInt32(); // 4   uint bindingOption.ID
                        var bindingOptionParam1 = packet.ReadUInt32(); // 4   uint bindingOption.nParam1
                    }

                    var bindingOptionType2 =
                        packet.ReadUInt8(); // 1   byte    bindingOptionType   //2 = Advanced elixir
                    var bindingOptionCount2 = packet.ReadUInt8(); // 1   byte    bindingOptionCount2
                    for (var bindingOptionIndex = 0; bindingOptionIndex < bindingOptionCount2; bindingOptionIndex++)
                    {
                        var bindingOptionSlot = packet.ReadUInt8(); // 1   byte bindingOption.Slot
                        var bindingOptionId = packet.ReadUInt32(); // 4   uint bindingOption.ID
                        var bindingOptionOptValue = packet.ReadUInt32(); // 4   uint bindingOption.OptValue
                    }
                }
                else if (item.TypeID2 == 2)
                {
                    if (item.TypeID3 == 1)
                    {
                        //ITEM_COS_P
                        var cosState = packet.ReadUInt8(); //1   byte    State
                        if (cosState == 2 || cosState == 3 || cosState == 4)
                        {
                            var cosRefObjId = packet.ReadUInt32(); // 4 uint RefObjID
                            var cosName = packet.ReadAscii(); // 2 ushort Name.Length //     * string Name
                            if (item.TypeID4 == 2)
                            {
                                //ITEM_COS_P (Ability)
                                var cosSecondsToRentEndTime = packet.ReadUInt32(); // 4 uint SecondsToRentEndTime
                            }

                            // Maybe?!
                            // might be service thing
                            var hasInventoryTime = packet.ReadUInt8(); // 1 byte unkByte0

                            if (hasInventoryTime == 0x1)
                            {
                                // Perhaps inventory span
                                var unk1222 = packet.ReadUInt8(); // NANI
                                var unk1223 = packet.ReadUInt32(); // THE
                                var unk1224 = packet.ReadUInt32(); // FUCK
                                var unk1225 = packet.ReadUInt32(); // ?!
                                var unk1226 = packet.ReadUInt8();
                                //Global.Logger.InfoFormat("{0}, {1}, {2}, {3}, {4}", unk1222, unk1223, unk1224,
                                //    unk1225, unk1226);
                            }
                        }
                    }
                    else if (item.TypeID3 == 2)
                    {
                        //ITEM_ETC_TRANS_MONSTER
                        var etcRefObjId = packet.ReadUInt32(); // 4   uint    RefObjID
                    }
                    else if (item.TypeID3 == 3)
                    {
                        //MAGIC_CUBE
                        var quantity =
                            packet
                                .ReadUInt32(); // 4   uint    Quantity        //Do not confuse with StackCount, this indicates the amount of elixirs in the cube
                    }
                }
                else if (item.TypeID2 == 3)
                {
                    //ITEM_ETC
                    var itemStackCount = packet.ReadUInt16(); // 2   ushort  item.StackCount

                    if (item.TypeID3 == 11)
                    {
                        if (item.TypeID4 == 1 || item.TypeID4 == 2)
                        {
                            //MAGICSTONE, ATTRSTONE
                            var attributeAssimilationProbability =
                                packet.ReadUInt8(); // 1   byte    AttributeAssimilationProbability
                        }
                    }
                    else if (item.TypeID3 == 14 && item.TypeID4 == 2)
                    {
                        //ITEM_MALL_GACHA_CARD_WIN
                        //ITEM_MALL_GACHA_CARD_LOSE
                        var magParamNum = packet.ReadUInt8(); // 1   byte    item.MagParamCount
                        for (var paramIndex = 0; paramIndex < magParamNum; paramIndex++)
                        {
                            var magParamType = packet.ReadUInt32(); //4   uint magParam.Type
                            var magParamValue = packet.ReadUInt32(); //4   uint magParam.Value
                        }
                    }
                }
            }
        }

        //AvatarInventory
        var avatarInventorySize = packet.ReadUInt8(); // 1 byte AvatarInventory.Size
        var avatarInventoryItemCount = packet.ReadUInt8(); // 1 byte AvatarInventory.ItemCount
        for (var i = 0; i < avatarInventoryItemCount; i++)
        {
            packet.ReadUInt8(); // 1 byte item.Slot
            var itemRentType = packet.ReadUInt32(); // 4 uint item.RentType
            if (itemRentType == 1)
            {
                packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                packet.ReadUInt16(); // 4 uint item.RentInfo.PeriodBeginTime
                packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodEndTime
            }
            else if (itemRentType == 2)
            {
                packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                packet.ReadUInt16(); // 2 ushort item.RentInfo.CanRecharge
                packet.ReadUInt32(); // 4 uint item.RentInfo.MeterRateTime
            }
            else if (itemRentType == 3)
            {
                packet.ReadUInt16(); // 2 ushort item.RentInfo.CanDelete
                packet.ReadUInt16(); // 2 ushort item.RentInfo.CanRecharge
                packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodBeginTime
                packet.ReadUInt32(); // 4 uint item.RentInfo.PeriodEndTime
                packet.ReadUInt32(); // 4 uint item.RentInfo.PackingTime
            }

            var itemRefItemId = packet.ReadUInt32(); // 4 uint item.RefItemID
            var item = SharedObjects.RefObjCommon[(int)itemRefItemId];

            if (item.TypeID1 == 3)
                //ITEM_        
                if (item.TypeID2 == 1)
                {
                    //ITEM_CH
                    //ITEM_EU
                    //AVATAR_
                    packet.ReadUInt8(); // 1 byte item.OptLevel
                    packet.ReadUInt64(); // 8 ulong item.Variance
                    packet.ReadUInt32(); // 4 uint item.Data //Durability
                    var itemMagParamNum = packet.ReadUInt8(); // 1 byte item.MagParamNum
                    for (var paramIndex = 0; paramIndex < itemMagParamNum; paramIndex++)
                    {
                        packet.ReadUInt32(); // 4 uint magParam.Type
                        packet.ReadUInt32(); // 4 uint magParam.Value
                    }

                    packet.ReadUInt8(); // 1 byte bindingOptionType //1 = Socket
                    var bindingOptionCount = packet.ReadUInt8(); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount;
                         bindingOptionIndex++)
                    {
                        packet.ReadUInt8(); // 1 byte bindingOption.Slot
                        packet.ReadUInt32(); // 4 uint bindingOption.ID
                        packet.ReadUInt32(); // 4 uint bindingOption.nParam1
                    }

                    packet.ReadUInt8(); // 1 byte bindingOptionType //2 = Advanced elixir
                    var bindingOptionCount2 = packet.ReadUInt8(); // 1 byte bindingOptionCount
                    for (var bindingOptionIndex = 0;
                         bindingOptionIndex < bindingOptionCount2;
                         bindingOptionIndex++)
                    {
                        packet.ReadUInt8(); // 1 byte bindingOption.Slot
                        packet.ReadUInt32(); // 4 uint bindingOption.ID
                        packet.ReadUInt32(); // 4 uint bindingOption.OptValue
                    }
                }
        }

        packet.ReadUInt8(); //1 byte unkByte1 //not a counter

        //Masteries
        var nextMastery = packet.ReadUInt8(); // 1   byte    nextMastery
        while (nextMastery == 1)
        {
            var masteryId = packet.ReadUInt32(); // 4   uint    mastery.ID
            var masteryLevel = packet.ReadUInt8(); // 1   byte    mastery.Level   
            nextMastery = packet.ReadUInt8(); // 1   byte    nextMastery
        }

        packet.ReadUInt8(); // 1   byte    unkByte2    //not a counter

        //Skills
        var nextSkill = packet.ReadUInt8(); // 1   byte    nextSkill
        while (nextSkill == 1)
        {
            var skillId = packet.ReadUInt32(); // 4   uint    skill.ID
            var skillEnabled = packet.ReadUInt8(); // 1   byte    skill.Enabled   

            nextSkill = packet.ReadUInt8(); // 1   byte    nextSkill
        }

        //Quests
        var completedQuestCount = packet.ReadUInt16(); // 2   ushort  CompletedQuestCount
        var completedQuests = packet.ReadUInt32Array(completedQuestCount); // *   uint[]  CompletedQuests

        var activeQuestCount = packet.ReadUInt8(); // 1   byte    ActiveQuestCount
        for (var activeQuestIndex = 0; activeQuestIndex < activeQuestCount; activeQuestIndex++)
        {
            var questRefQuestId = packet.ReadUInt32(); // 4   uint    quest.RefQuestID
            var questAchievementCount = packet.ReadUInt8(); // 1   byte    quest.AchievementCount
            var questRequiresAutoShareParty = packet.ReadUInt8(); // 1   byte    quest.RequiresAutoShareParty
            var questType = packet.ReadUInt8(); // 1   byte    quest.Type
            if (questType == 28)
            {
                var questRemainingTime = packet.ReadUInt32(); // 4   uint    remainingTime
            }

            var questStatus = packet.ReadUInt8(); // 1   byte    quest.Status

            if (questType != 8)
            {
                var questObjectiveCount = packet.ReadUInt8(); // 1   byte    quest.ObjectiveCount
                for (var objectiveIndex = 0; objectiveIndex < questObjectiveCount; objectiveIndex++)
                {
                    var questObjectiveId = packet.ReadUInt8(); // 1   byte    objective.ID
                    var questObjectiveStatus =
                        packet.ReadUInt8(); // 1   byte    objective.Status        //0 = Done, 1  = On
                    var questObjectiveName =
                        packet.ReadAscii(); // 2   ushort  objective.Name.Length // *   string  objective.Name
                    var objectiveTaskCount = packet.ReadUInt8(); // 1   byte    objective.TaskCount
                    for (var taskIndex = 0; taskIndex < objectiveTaskCount; taskIndex++)
                    {
                        var questTaskValue = packet.ReadUInt32(); // 4   uint    task.Value
                    }
                }
            }

            if (questType == 88)
            {
                var refObjCount = packet.ReadUInt8(); // 1   byte    RefObjCount
                for (var refObjIndex = 0; refObjIndex < refObjCount; refObjIndex++)
                    packet.ReadUInt32(); // 4   uint    RefObjID    //NPCs
            }
        }

        packet.ReadUInt8(); // 1   byte    unkByte3        //Structure changes!!!

        //CollectionBook
        var startedCollectionCount = packet.ReadUInt32(); // 4   uint    CollectionBookStartedThemeCount
        for (var i = 0; i < startedCollectionCount; i++)
        {
            var themeIndex = packet.ReadUInt32(); // 4   uint    theme.Index
            var themeStartedDateTime = packet.ReadUInt32(); // 4   uint    theme.StartedDateTime   //SROTimeStamp
            var themePages = packet.ReadUInt32(); // 4   uint    theme.Pages
        }

        session.SessionData.UniqueCharId = packet.ReadUInt32(); // 4   uint    UniqueID

        //Position
        session.SessionData.LatestRegionId = packet.ReadUInt16(); // 2   ushort  Position.RegionID
        session.SessionData.PositionX = packet.ReadFloat(); // 4   float   Position.X
        session.SessionData.PositionY = packet.ReadFloat(); // 4   float   Position.Y
        session.SessionData.PositionZ = packet.ReadFloat(); // 4   float   Position.Z
        var positionAngle = packet.ReadUInt16(); // 2   ushort  Position.Angle

        //Movement
        var movementHasDestination = packet.ReadUInt8(); // 1   byte    Movement.HasDestination
        var movementType = packet.ReadUInt8(); // 1   byte    Movement.Type
        if (movementHasDestination == 1)
        {
            var movementDestionationRegion = packet.ReadUInt16(); // 2   ushort  Movement.DestinationRegion        
            if (session.SessionData.LatestRegionId < short.MaxValue)
            {
                //World
                var movementDestinationOffsetX = packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetX
                var movementDestinationOffsetY = packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetY
                var movementDestinationOffsetZ = packet.ReadUInt16(); // 2   ushort  Movement.DestinationOffsetZ
            }
            else
            {
                //Dungeon
                var movementDestinationOffsetX = packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetX
                var movementDestinationOffsetY = packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetY
                var movementDestinationOffsetZ = packet.ReadUInt32(); // 4   uint  Movement.DestinationOffsetZ
            }
        }
        else
        {
            var movementSource =
                packet.ReadUInt8(); // 1   byte    Movement.Source     //0 = Spinning, 1 = Sky-/Key-walking
            var movementAngle =
                packet.ReadUInt16(); // 2   ushort  Movement.Angle      //Represents the new angle, character is looking at
        }

        //State
        session.SessionData.State.LifeState =
            (LifeState)packet.ReadUInt8(); // 1   byte    State.LifeState         //1 = Alive, 2 = Dead
        packet.ReadUInt8(); // 1   byte    State.unkByte0
        session.SessionData.State.MotionState =
            (MotionState)packet
                .ReadUInt8(); // 1   byte    State.MotionState       //0 = None, 2 = Walking, 3 = Running, 4 = Sitting
        session.SessionData.State.BodyState = (BodyState)packet
            .ReadUInt8(); // 1   byte    State.Status            //0 = None, 1 = Hwan, 2 = Untouchable, 3 = GameMasterInvincible, 5 = GameMasterInvisible, 5 = ?, 6 = Stealth, 7 = Invisible
        var stateWalkSpeed = packet.ReadFloat(); // 4   float   State.WalkSpeed
        var stateRunSpeed = packet.ReadFloat(); // 4   float   State.RunSpeed
        var stateHwanSpeed = packet.ReadFloat(); // 4   float   State.HwanSpeed
        var stateBuffCount = packet.ReadUInt8(); // 1   byte    State.BuffCount

        for (var i = 0; i < stateBuffCount; i++)
        {
            var buffRefSkillId = packet.ReadUInt32(); // 4   uint    Buff.RefSkillID
            var buffDuration = packet.ReadUInt32(); // 4   uint    Buff.Duration

            var skill = SharedObjects.RefSkill[(int)buffRefSkillId];

            if (skill == null) continue;
            if (skill.ParamsContains(1701213281))
            {
                //1701213281 -> atfe -> "auto transfer effect" like Recovery Division
                var isCreator = packet.ReadUInt8(); // 1   bool    IsCreator
            }
        }

        var name = packet.ReadAscii(); // 2   ushort  Name.Length // *   string  Name
        session.SessionData.Charname = name;
        var jobName = packet.ReadAscii(); // 2   ushort  JobName.Length // *   string  JobName
        session.SessionData.JobType = (Job)packet.ReadUInt8(); // 1   byte    JobType
        var jobLevel = packet.ReadUInt8(); // 1   byte    JobLevel
        var jobExp = packet.ReadUInt32(); // 4   uint    JobExp
        var jobContribution = packet.ReadUInt32(); // 4   uint    JobContribution
        var jobReward = packet.ReadUInt32(); // 4   uint    JobReward
        session.SessionData.State.PvpState =
            (PvpState)packet.ReadUInt8(); // 1   byte    PVPState                //0 = White, 1 = Purple, 2 = Red
        session.SessionData.OnTransport = packet.ReadBool(); // 1   byte    TransportFlag
        session.SessionData.State.BattleState = (BattleState)packet.ReadUInt8(); // 1   byte    InCombat
        if (session.SessionData.OnTransport)
        {
            session.SessionData.TransportUniqueId = packet.ReadUInt32(); // 4   uint    Transport.UniqueID
        }

        var pvpFlag =
            packet.ReadUInt8(); // 1   byte    PVPFlag                 //0 = Red Side, 1 = Blue Side, 0xFF = None
        var guideFlag = packet.ReadUInt64(); // 8   ulong   GuideFlag
        var jid = packet.ReadUInt32(); // 4   uint    JID
        var gmFlag = packet.ReadUInt8(); // 1   byte    GMFlag

        var activationFlag =
            packet.ReadUInt8(); // 1   byte    ActivationFlag          //ConfigType:0 --> (0 = Not activated, 7 = activated)
        var hotkeyCount = packet.ReadUInt8(); // 1   byte    Hotkeys.Count           //ConfigType:1
        for (var i = 0; i < hotkeyCount; i++)
        {
            var hotkeySlotSeq = packet.ReadUInt8(); // 1   byte    hotkey.SlotSeq
            var hotkeySlotContentType = packet.ReadUInt8(); // 1   byte    hotkey.SlotContentType
            var hotkeySlotData = packet.ReadUInt32(); // 4   uint    hotkey.SlotData
        }

        var autoHpConfig = packet.ReadUInt16(); // 2   ushort  AutoHPConfig            //ConfigType:11
        var autoMpConfig = packet.ReadUInt16(); // 2   ushort  AutoMPConfig            //ConfigType:12
        var autoUniversalConfig = packet.ReadUInt16(); // 2   ushort  AutoUniversalConfig     //ConfigType:13
        var autoPotionDelay = packet.ReadUInt8(); // 1   byte    AutoPotionDelay         //ConfigType:14

        var blockedWhisperCount = packet.ReadUInt8(); // 1   byte    blockedWhisperCount
        for (var i = 0; i < blockedWhisperCount; i++)
        {
            var target = packet.ReadAscii(); // 2   ushort  Target.Length // *   string  Target
        }

        packet.ReadUInt32(); // 4   uint    unkUShort0      //Structure changes!!!
        packet.ReadUInt8(); // 1   byte    unkByte4        //Structure changes!!!

        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_MOVEMENT_SERVER(Packet packet, ISession session, object obj)
    {
        var target = packet.ReadUInt32(); // Unique ID from player
        if (target != session.SessionData.UniqueCharId)
        {
            return new PacketResult();
        }

        // TODO FIGURE OUT IF WE REALLY WANNA USE THIS
        // yes we want to use this at a later stage
        // specially to track sectorX and sectorY
        // var movement = Movement.MotionFromPacket(packet);
        //
        // try
        // {
        //     Global.Logger.Debug("---------------------");
        //     Global.Logger.Debug("X: " + movement.Destination.X);        
        //     Global.Logger.Debug("XOffset: " + movement.Destination.XOffset);        
        //     Global.Logger.Debug("XSectorOffset: " + movement.Destination.XSectorOffset);     
        //     Global.Logger.Debug("Y: " + movement.Destination.Y);        
        //     Global.Logger.Debug("YOffset: " + movement.Destination.YOffset);        
        //     Global.Logger.Debug("YSectorOffset: " + movement.Destination.YSectorOffset);     
        //     Global.Logger.Debug("RegionId: " + movement.Destination.Region.GetId());     
        //     Global.Logger.Debug("RegionX: " + movement.Destination.Region.GetX());
        //     Global.Logger.Debug("RegionY: " + movement.Destination.Region.GetY());
        //     Global.Logger.Debug("---------------------");
        // }
        // catch (Exception e)
        // {
        //     Global.Logger.Debug(e.ToString());
        // }

        if (target == session.SessionData.UniqueCharId ||
            (session.SessionData.Vehicle != null && session.SessionData.Vehicle.UniqueId == target))
        {
            if (session.TimerManager.IsStarted() && session.TimerManager.IsStopOnMove() &&
                target == session.SessionData.UniqueCharId)
            {
                session.TimerManager.Stop();
            }

            if (session.TimerManager.IsStarted() && session.TimerManager.IsStopOnVehicleMove() &&
                session.SessionData.Vehicle != null && session.SessionData.Vehicle.UniqueId == target)
            {
                session.TimerManager.Stop();
            }

            // sky = 0, ground = 1
            var groundClick = packet.ReadUInt8(); //sky or ground click
            if (groundClick == 0x00) return new PacketResult();

            session.SessionData.LatestRegionId = packet.ReadUInt16(); // Region ID
            if (session.SessionData.LatestRegionId >= short.MaxValue)
            {
                var x = packet.ReadUInt32();
                var y = packet.ReadUInt32();
                var z = packet.ReadUInt32();
            }
            else
            {
                session.SessionData.PositionX = packet.ReadUInt16();
                session.SessionData.PositionY = packet.ReadUInt16();
                session.SessionData.PositionZ = packet.ReadUInt16();
            }

            return new PacketResult();
        }

        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_TELEPORT_USE(Packet packet, ISession session, object obj)
    {
        session.CharacterGameReady = false;
        session.SessionData.LastClientReady = null;
        EventFactory.Publish(EventFactoryNames.OnCharacterGameReadyChange, session, false);
        if (session.CountdownManager.IsStarted() && session.CountdownManager.IsStopOnTeleport())
        {
            session.CountdownManager.Stop();
        }

        if (session.TimerManager.IsStarted())
        {
            session.TimerManager.Stop();
        }

        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_GAME_READY(Packet packet, ISession session, object obj)
    {
        // fix to not crash on autonotice
        session.CharacterGameReady = true;
        session.SessionData.LastClientReady = Helper.GetCurrentTimeMillis();
        if (!session.SessionData.FirstSpawn)
        {
            session.SessionData.FirstSpawn = true;
            EventFactory.Publish(EventFactoryNames.OnCharacterFirstSpawn, session);
        }
        EventFactory.Publish(EventFactoryNames.OnCharacterGameReadyChange, session, true);

        if (session.CountdownManager.IsStarted())
        {
            if (!session.CountdownManager.IsStopOnTeleport())
            {
                session.CountdownManager.Resend();
            }
            else
            {
                session.CountdownManager.Stop();
            }
        }

        if (session.TimerManager.IsStarted())
        {
            session.TimerManager.Stop();
        }

        Task.Run(() =>
        {
            Thread.Sleep(1000);
            foreach (var agentSession in SharedObjects.AgentSessions)
            {
                if (!agentSession.CharacterGameReady)
                {
                    continue;
                }

                if (agentSession.SessionData.Charid == session.SessionData.Charid)
                {
                    continue;
                }

                if (agentSession.TimerManager.IsStarted() && agentSession.TimerManager.IsBroadcast())
                {
                    agentSession.TimerManager.Send(session);
                }
            }
        });


        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_ENVIRONMENT_CELESTIAL_POSITION(Packet packet, ISession session, object obj)
    {
        if (session.CharScreen)
        {
            EventFactory.Publish(EventFactoryNames.OnUserLeaveCharScreen, session);
        }
        session.CharScreen = false;
        //.CharacterData.UniqueCharId = packet.ReadUInt32();
        return new PacketResult();
    }

    private async Task<PacketResult> CLIENT_AGENT_CHARACTER_SELECTION_ACTION_REQUEST(Packet packet, ISession session,
        object obj)
    {
        if (!session.CharScreen)
        {
            Global.Logger.WarnFormat("Client {0}({1}) attempted to send 0x7007 outside char screen!",
                session.SessionData.Charname,
                packet.Opcode);
            return new PacketResult(PacketResultType.Disconnect);
        }

        await new CLIENT_AGENT_CHARACTER_SELECTION_ACTION_REQUEST().Read(packet);
        if (packet.RemainingRead() != 0)
        {
            Global.Logger.WarnFormat("Client {0}({1}) attempted to crash SHARD_MANAGER!", session.SessionData.Charname,
                packet.Opcode);
            return new PacketResult(PacketResultType.Disconnect);
        }


        return new PacketResult();
    }

    private async Task<PacketResult> CLIENT_EXPLOIT_GSCRASH(Packet packet, ISession session, object obj)
    {
        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use GS_CRASH_EXPLOIT - {1:X}", session.SessionData.Charname,
            packet.Opcode);
        return new PacketResult(PacketResultType.Disconnect);
    }

    private async Task<PacketResult> AGENT_SKILL_MASTERY_LEARN(Packet packet, ISession session, object obj)
    {
        packet.ReadUInt32(); // masteryid
        var level = packet.ReadUInt8();

        if (level == 1) return new PacketResult();

        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use SKILL_EXPLOIT - {1:X}", session.SessionData.Charname,
            packet.Opcode);
        return new PacketResult(PacketResultType.Disconnect);
    }

    private async Task<PacketResult> CLIENT_PLAYER_BERSERK(Packet packet, ISession session, object obj)
    {
        var flag = packet.ReadUInt8();
        if (flag == 1) return new PacketResult();

        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use INVIS EXPLOIT - {1:X}", session.SessionData.Charname,
            packet.Opcode);
        return new PacketResult(PacketResultType.Disconnect);
    }

    private async Task<PacketResult> AGENT_LOGOUT(Packet packet, ISession session, object obj)
    {
        if (session.CharScreen)
        {
            Global.Logger.WarnFormat("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 1",
                session.SessionData.Charname,
                packet.Opcode);
            return new PacketResult(PacketResultType.Disconnect);
        }

        if (session.SessionData.Charid <= 0)
        {
            Global.Logger.WarnFormat("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 2",
                session.SessionData.Charname,
                packet.Opcode);
            return new PacketResult(PacketResultType.Disconnect);
        }

        var logoutMode = packet.ReadUInt8();
        if (logoutMode > 2)
        {
            Global.Logger.WarnFormat("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 3",
                session.SessionData.Charname,
                packet.Opcode);
            return new PacketResult(PacketResultType.Disconnect);
        }

        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_MAGICOPTION_GRANT(Packet packet, ISession session, object obj)
    {
        var avatarBlue = packet.ReadAscii().ToLower();
        if (avatarBlue.Contains("avatar")) return new PacketResult();

        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use AVATAR_EXPLOIT - {1:X}", session.SessionData.Charname,
            packet.Opcode);
        return new PacketResult(PacketResultType.Disconnect);
    }

    private async Task<PacketResult> AGENT_GUILD_UPDATE_NOTICE(Packet packet, ISession session, object obj)
    {
        var guildNoticeTitle = packet.ReadAscii();
        var guildNoticeMessage = packet.ReadAscii();

        if (!guildNoticeMessage.Contains('\'') &&
            !guildNoticeMessage.Contains('\"') &&
            !guildNoticeMessage.Contains('-') &&
            !guildNoticeTitle.Contains('\'') &&
            !guildNoticeTitle.Contains('\"') &&
            !guildNoticeTitle.Contains('-'))
            return new PacketResult();

        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use GUILD_SQL_INJECTION - {1:X}",
            session.SessionData.Charname,
            packet.Opcode);
        await session.SendNotice(
            "You're not allowed to use special characters in this textfield. We've replaced them for you.");

        guildNoticeTitle = guildNoticeTitle
            .Replace('\'', ' ').Replace('-', ' ').Replace('\"', ' ').Replace(';', ' ');
        guildNoticeMessage = guildNoticeMessage
            .Replace('\'', ' ').Replace('-', ' ').Replace('\"', ' ')
            .Replace(';', ' ');

        var newPacket = new Packet(packet.Opcode, packet.Encrypted, packet.Massive);
        newPacket.WriteAscii(guildNoticeTitle);
        newPacket.WriteAscii(guildNoticeMessage);

        return new PacketResult(newPacket, PacketResultType.Override);
    }

    private async Task<PacketResult> AGENT_SIEGE_ACTION(Packet packet, ISession session, object obj)
    {
        packet.ReadUInt32();
        var unk2 = packet.ReadUInt8();
        uint unk3 = 0;
        if (unk2 == 1 || unk2 == 2 || unk2 == 26) unk3 = packet.ReadUInt32();

        // About guild
        if (unk2 != 26 || unk3 != 1) return new PacketResult();
        var message = packet.ReadAscii();

        if (!message.Contains("\'") && !message.Contains("\"") && !message.Contains("-"))
            return new PacketResult();

        Global.Logger.WarnFormat("EXPLOIT - {0} tried to use FW_SQL_INJECTION - {1:X}",
            session.SessionData.Charname,
            packet.Opcode);
        await session.SendNotice("You're not allowed to use special characters in this textfield.");
        return new PacketResult(PacketResultType.Block);
    }

    private async Task<PacketResult> AGENT_AUTH(Packet packet, ISession session, object obj)
    {
        if (packet.ReadUInt8() == 1)
        {
            session.UserLoggedIn = true;
            EventFactory.Publish(EventFactoryNames.OnUserAgentLogin, session);
        }

        if (session.UserLoggedIn)
        {
            session.CharScreen = true;
            EventFactory.Publish(EventFactoryNames.OnUserJoinCharScreen, session);
        }

        return new PacketResult();
    }

    private async Task<PacketResult> AGENT_CHARACTER_SELECTION_JOIN(Packet packet, ISession session, object obj)
    {
        if (session.CharnameSent)
            return new PacketResult(PacketResultType.Block);

        if (!session.CharScreen)
        {
            Global.Logger.WarnFormat("Client {0}({1}) attempted to send 0x7001 outside char screen!",
                session.ClientGuid, session.ClientIp);
            return new PacketResult(PacketResultType.Disconnect);
        }

        session.SessionData.Charname = packet.ReadAscii();

        if (session.PacketLength - session.SessionData.Charname.Length != 2)
        {
            Global.Logger.WarnFormat("Client {0}({1})attempted to modify 0x7001!", session.ClientGuid,
                session.ClientIp);
            return new PacketResult(PacketResultType.Disconnect);
        }

        session.CharnameSent = true;
        EventFactory.Publish(EventFactoryNames.OnUserCharnameSent, session);
        
        using var db = new SRO_VT_SHARD();
        session.SessionData.Charid =
            (await db._Chars.Where(x => x.CharName16 == session.SessionData.Charname).FirstAsync()).CharID;
        session.SessionData.JID =
            (await db._Users.Where(x => x.CharID == session.SessionData.Charid).FirstAsync()).UserJID;

        return new PacketResult();
    }
}