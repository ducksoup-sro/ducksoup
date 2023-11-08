using System;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.EventFactory;
using API.ServiceFactory;
using API.Session;
using Database.VSRO188.Context;
using DuckSoup.Library.Party;
using DuckSoup.Library.Server;
using DuckSoup.Library.Session;
using Microsoft.EntityFrameworkCore;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Client;
using PacketLibrary.VSRO188.Agent.Enums.Logout;
using PacketLibrary.VSRO188.Agent.Server;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent;

public class VSRO188_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public VSRO188_AgentServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var partyManagerHandlers = new PartyManagerHandlers(PacketHandler);

        #region Exploits

        // charname modify and not really logged in Exploit - 0x7001 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4232366-release-disconnect-players-exploit-found-iwa-4.html 
        PacketHandler.RegisterClientHandler<CLIENT_CHARACTER_SELECTION_JOIN_REQUEST>(1, ClientCharacterSelectionJoin);

        // SQL Injection - 0x705E - Also contains Tax / checkout checks - https://www.elitepvpers.com/forum/sro-private-server/4141360-information-sql-injection-ingame.html
        PacketHandler.RegisterClientHandler<CLIENT_SIEGE_ACTION>(1, ClientSiegeAction);

        // Guild Notice - 0x70F9 - Better safe than sorry.
        PacketHandler.RegisterClientHandler<CLIENT_GUILD_UPDATE_NOTICE>(1, ClientGuildUpdateNotice);

        // Avatar Exploit - 0x34A9 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/3991992-release-invincible-avatar-magopt-exploit-3.html
        PacketHandler.RegisterClientHandler<CLIENT_MAGICOPTION_GRANT>(1, ClientMagicOptionGrant);

        // [x] Crash Exploit - 0x7005 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/4232366-release-disconnect-players-exploit-found-iwa.html
        PacketHandler.RegisterClientHandler<CLIENT_LOGOUT_REQUEST>(1, ClientLogoutRequest);

        // same as above
        PacketHandler.RegisterClientHandler<CLIENT_CHARACTER_SELECTION_ACTION_REQUEST>(1,
            ClientCharacterSelectionActionRequest);

        // Zerk Exploit - 0x70A7 - https://www.elitepvpers.com/forum/sro-pserver-guides-releases/3991992-release-invincible-avatar-magopt-exploit-3.html
        PacketHandler.RegisterClientHandler<CLIENT_PLAYER_BERSERK>(1, ClientPlayerBerserk);

        // Skill Exploit - 0x70A2 - https://www.maxigame.com/forum/t/251583-meshur-vsro-mastery-exploit-ini-delirius-engelleme
        PacketHandler.RegisterClientHandler<CLIENT_SKILL_MASTERY_LEARN_REQUEST>(1, ClientSkillMasteryLearn);

        // Exploit Prevention
        PacketHandler.RegisterModuleHandler<SERVER_AUTH_RESPONSE>(1, ServerAuth);

        #endregion


        #region fixes

        // PacketHandler.RegisterClientHandler<CLIENT_MAINACTION>(1); // Snow Shield fix

        #endregion

        #region Data

        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_BEGIN>(CHARACTER_DATA_BEGIN);
        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA>(CHARACTER_DATA);
        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_END>(CHARACTER_DATA_END);

        #endregion

        // PacketHandler.RegisterModuleHandler<SERVER_MOVEMENT>(SERVER_MOVEMENT);
    }

    /*
     *     private async Task<PacketResult> AGENT_ENVIRONMENT_CELESTIAL_POSITION(Packet packet, ISession session, object obj)
    {
        if (session.CharScreen)
        {
            EventFactory.Publish(EventFactoryNames.OnUserLeaveCharScreen, session);
        }

        session.CharScreen = false;
        //.CharacterData.UniqueCharId = packet.ReadUInt32();
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

        var hasValue = SharedObjects.RefObjCommon.TryGetValue((int)refObjId, out var obj);

        if (!hasValue)
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
                    case 2: // Moveable?
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
                            case 4: // cos guard
                            {
                                var bionic = new SpawnedNpc(refObjId);
                                bionic.ParseBionicDetails(packet);
                                bionic.Deserialize(packet);

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
     */

    // TODO :: EXPLOITS
    private async Task<Packet> ServerAuth(SERVER_AUTH_RESPONSE data, ISession session)
    {
        session.SetData(Data.CharInfo, new CharInfo());
        if (data.Result == 0x01)
        {
            session.SetData(Data.UserLoggedIn, true);
            EventFactory.Publish(EventFactoryNames.OnUserAgentLogin, session);
        }

        session.GetData(Data.UserLoggedIn, out var loggedIn, false);
        if (loggedIn)
        {
            session.SetData(Data.CharScreen, true);
            EventFactory.Publish(EventFactoryNames.OnUserJoinCharScreen, session);
        }

        return data;
    }

    private async Task<Packet> ClientSkillMasteryLearn(CLIENT_SKILL_MASTERY_LEARN_REQUEST data, ISession session)
    {
        if (data.Amount == 1)
        {
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        Log.Warning("EXPLOIT - {0} tried to use SKILL_EXPLOIT - {1:X}", charInfo?.CharName, data.MsgId);
        data.Status = 0x01;
        data.ResultType = PacketResultType.Disconnect;
        return data;
    }

    private async Task<Packet> ClientPlayerBerserk(CLIENT_PLAYER_BERSERK data, ISession session)
    {
        data.TryRead(out byte result);
        if (result == 1)
        {
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        Log.Information("EXPLOIT - {0} tried to use INVIS EXPLOIT - {1:X}", charInfo?.CharName, data.MsgId);
        data.Status = 0x01;
        data.ResultType = PacketResultType.Disconnect;
        return data;
    }

    private async Task<Packet> ClientCharacterSelectionActionRequest(CLIENT_CHARACTER_SELECTION_ACTION_REQUEST data,
        ISession session)
    {
        session.GetData(Data.CharScreen, out var charScreen, false);
        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        if (!charScreen)
        {
            Log.Warning("Client {0}({1}) attempted to send 0x7007 outside char screen!", charInfo?.CharName,
                data.MsgId);
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        if (data.RemainingRead() != 0)
        {
            Log.Warning("Client {0}({1}) attempted to crash SHARD_MANAGER!", charInfo?.CharName, data.MsgId);
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        return data;
    }

    private async Task<Packet> ClientLogoutRequest(CLIENT_LOGOUT_REQUEST data, ISession session)
    {
        session.GetData(Data.CharScreen, out var charScreen, false);
        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        if (charScreen)
        {
            Log.Warning("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 1", charInfo?.CharName, data.MsgId);
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        session.GetData(Data.CharId, out var charId, 0);
        if (charId <= 0)
        {
            Log.Warning("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 2", charInfo?.CharName, data.MsgId);
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        if (data.LogoutMode > LogoutMode.Restart)
        {
            Log.Warning("EXPLOIT - {0} tried to use AS_CRASH_EXPLOIT - {1:X} at 3", charInfo?.CharName, data.MsgId);
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        return data;
    }

    private async Task<Packet> ClientMagicOptionGrant(CLIENT_MAGICOPTION_GRANT data, ISession session)
    {
        data.TryRead(out string avatarBlue);
        if (avatarBlue.Contains("avatar"))
        {
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        Log.Warning("EXPLOIT - {0} tried to use AVATAR_EXPLOIT - {1:X}", charInfo?.CharName, data.MsgId);
        data.Status = 0x01;
        data.ResultType = PacketResultType.Disconnect;
        return data;
    }

    private async Task<Packet> ClientGuildUpdateNotice(CLIENT_GUILD_UPDATE_NOTICE data, ISession session)
    {
        if (!data.Title.Contains('\'') &&
            !data.Title.Contains('\"') &&
            !data.Title.Contains('-') &&
            !data.Text.Contains('\'') &&
            !data.Text.Contains('\"') &&
            !data.Text.Contains('-'))
        {
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        Log.Warning(
            "EXPLOIT - {0} tried to use GUILD_SQL_INJECTION, this can happen accidentally, fixing the packet - no disconnect - {1:X}",
            charInfo?.CharName, data.MsgId);
        data.Status = 0x01;
        await session.SendNotice(
            "You're not allowed to use special characters in this textfield. We've replaced them for you.");

        data.Text = data.Text
            .Replace('\'', ' ').Replace('-', ' ').Replace('\"', ' ').Replace(';', ' ');
        data.Title = data.Title
            .Replace('\'', ' ').Replace('-', ' ').Replace('\"', ' ')
            .Replace(';', ' ');
        return data;
    }

    private async Task<Packet> ClientSiegeAction(CLIENT_SIEGE_ACTION data, ISession session)
    {
        data.TryRead(out uint uUnk0)
            .TryRead(out byte bUnk0);
        uint uUnk1 = 0;
        if (bUnk0 == 1 || bUnk0 == 2 || bUnk0 == 26)
        {
            data.TryRead(out uUnk1);
        }

        // About guild
        if (bUnk0 != 26 || uUnk1 != 1)
        {
            return data;
        }

        data.TryRead(out string message);
        if (!message.Contains('\'') && !message.Contains('"') && !message.Contains('-'))
        {
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        Log.Warning("EXPLOIT - {0} tried to use FW_SQL_INJECTION this can happen accidentally - no disconnect - {1:X}",
            charInfo?.CharName, data.MsgId);
        data.Status = 0x01;
        data.ResultType = PacketResultType.Block;
        await session.SendNotice("You're not allowed to use special characters in this textfield.");
        return data;
    }

    private async Task<Packet> ClientCharacterSelectionJoin(CLIENT_CHARACTER_SELECTION_JOIN_REQUEST data,
        ISession session)
    {
        session.GetData(Data.CharNameSent, out var charnameSent, false);
        if (charnameSent)
        {
            // this can happen twice, we block it once we've received the charname
            data.Status = 0x01;
            data.ResultType = PacketResultType.Block;
            return data;
        }

        session.GetData(Data.CharScreen, out var charScreen, false);
        if (!charScreen)
        {
            Log.Warning("Client {0}({1}) attempted to send 0x7001 outside char screen!",
                session.Guid, session.RemoteEndPoint.Address.ToString());
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        if (data.RemainingRead() != 0)
        {
            Log.Warning("Client {0}({1})attempted to modify 0x7001!", session.Guid,
                session.RemoteEndPoint.Address.ToString());
            data.Status = 0x01;
            data.ResultType = PacketResultType.Disconnect;
            return data;
        }

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        charInfo.CharName = data.Name;
        session.SetData(Data.CharNameSent, true);
        EventFactory.Publish(EventFactoryNames.OnUserCharnameSent, session);

        await using var db = new SRO_VT_SHARD();
        var charId = (await db._Chars.Where(x => x.CharName16 == data.Name).FirstAsync()).CharID;
        var jid = (await db._Users.Where(x => x.CharID == charId).FirstAsync()).UserJID;
        session.SetData(Data.CharId, charId);
        charInfo.Jid = (uint)jid;
        return data;
    }

    private async Task<Packet> SERVER_MOVEMENT(SERVER_MOVEMENT_RESPONSE data, ISession session)
    {
        Log.Debug("---------------------");
        // Log.Debug("X: " + data.Movement.Destination.X);        
        // Log.Debug("XOffset: " + data.Movement.Destination.XOffset);        
        // Log.Debug("XSectorOffset: " + data.Movement.Destination.XSectorOffset);     
        // Log.Debug("Y: " + data.Movement.Destination.Y);        
        // Log.Debug("YOffset: " + data.Movement.Destination.YOffset);        
        // Log.Debug("YSectorOffset: " + data.Movement.Destination.YSectorOffset);     
        // Log.Debug("RegionId: " + data.Movement.Destination.Region.Id);     
        // Log.Debug("RegionX: " + data.Movement.Destination.Region.X);
        // Log.Debug("RegionY: " + data.Movement.Destination.Region.Y);
        var distance = data.Movement.Source.DistanceTo(data.Movement.Destination);
        Log.Debug("Source: " + data.Movement.Source.ToString());
        Log.Debug("Destination: " + data.Movement.Destination.ToString());
        Log.Debug("Distance: " + distance);
        Log.Debug("---------------------");

        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        Log.Debug("walkSpeed: {0} - ETA: {1}", charInfo.WalkSpeed / 10f, distance / (charInfo.WalkSpeed / 10f));
        Log.Debug("runSpeed: {0} - ETA: {1}", charInfo.RunSpeed / 10f, distance / (charInfo.RunSpeed / 10f));
        Log.Debug("hwanSpeed: {0} - ETA: {1}", charInfo.HwanSpeed / 10f, distance / (charInfo.HwanSpeed / 10f));
        Log.Debug("motionState: " + charInfo.MotionState);

        // Task.Run(async () =>
        // {
        //     Thread.Sleep((int)(distance / (charInfo.walkSpeed / 10f) * 1000));
        //     session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "walk"));
        // });
        //
        // Task.Run(async () =>
        // {
        //     Thread.Sleep((int)(distance / (charInfo.runSpeed / 10f) * 1000));
        //     session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "run"));
        // });
        //
        // Task.Run(async () =>
        // {
        //     Thread.Sleep((int)(distance / (charInfo.hwanSpeed / 10f) * 1000));
        //     session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "hwan"));
        // });

        return data;
    }

    private async Task<Packet> CHARACTER_DATA_BEGIN(SERVER_CHARACTER_DATA_BEGIN data, ISession session)
    {
        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        charInfo.Initialize();

        return data;
    }

    private async Task<Packet> CHARACTER_DATA(SERVER_CHARACTER_DATA data, ISession session)
    {
        try
        {
            session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
            charInfo.Append(data);
            data.ResultType = PacketResultType.Block;
        }
        catch (Exception ex)
        {
            Log.Information("{0} \n {1}", ex.Message, ex.StackTrace);
        }

        return data;
    }

    private async Task<Packet> CHARACTER_DATA_END(SERVER_CHARACTER_DATA_END data, ISession session)
    {
        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        var charPacket = charInfo.GetPacket();
        if (charPacket == null)
        {
            return data;
        }

        await charInfo.Read();
        await session.SendToClient(charPacket);
        charInfo.Clear();
        return data;
    }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        _sharedObjects.AgentSessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        if (_sharedObjects.AgentSessions.Contains(session)) _sharedObjects.AgentSessions.Remove(session);
    }
}