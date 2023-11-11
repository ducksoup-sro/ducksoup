using System;
using System.Threading.Tasks;
using API.Extensions;
using API.Session;
using Database.VSRO188;
using DuckSoup.Library.Session;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Cos;
using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using PacketLibrary.VSRO188.Agent.Server;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent.Vsro;

public class EntityParsingHandler
{
    public EntityParsingHandler(IPacketHandler packetHandler)
    {
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_SPAWN>(EntitySingleSpawn);
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_DESPAWN>(EntitySingleDespawn);
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_GROUPSPAWN_BEGIN>(EntityGroupSpawnBegin);
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_GROUPSPAWN_END>(EntityGroupSpawnEnd);
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_GROUPSPAWN_DATA>(EntityGroupSpawnData);

        packetHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_BEGIN>(CharacterDataBegin);
        packetHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA>(CharacterData);
        packetHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_END>(CharacterDataEnd);

        packetHandler.RegisterModuleHandler<SERVER_ENTITY_STATE_UPDATE>(EntityStateUpdate);
        packetHandler.RegisterModuleHandler<SERVER_COS_UPDATE_RIDESTATE_RESPONSE>(CosUpdateRidestateResponse);
        packetHandler.RegisterModuleHandler<SERVER_COS_UPDATE>(CosUpdate);
        packetHandler.RegisterModuleHandler<SERVER_COS_INFO>(CosInfo);
    }

    private async Task<Packet> CosInfo(SERVER_COS_INFO data, ISession session)
    {
        data.TryRead(out uint uniqueId)
            .TryRead(out uint objectId);

        var objCommon = await Cache.GetRefObjCommonAsync((int)objectId);
        if (objCommon == null)
        {
            return data;
        }

        var objChar = await Cache.GetRefObjCharAsync(objCommon.Link);
        if (objChar == null)
        {
            return data;
        }

        if (objCommon.TypeID2 == 2 && objCommon.TypeID3 == 3)
        {
            data.TryRead(out int hp)
                .TryRead(out int maxHp);
            maxHp = maxHp != 0 && maxHp != 200 ? maxHp : objChar.MaxHP;

            switch (objCommon.TypeID4)
            {
                case 1:
                    session.SetData(Data.Transport, new Transport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    });
                    break;
                case 2:
                    var jobTransport = new JobTransport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                        Inventory = new InventoryItemCollection(data),
                    };
                    data.TryRead(out jobTransport.OwnerUniqueId);
                    session.SetData(Data.JobTransport, jobTransport);
                    break;
                case 3:
                    var growth = new Growth
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    growth.Deserialize(data);
                    session.SetData(Data.Growth, growth);
                    break;
                case 4:
                    var ability = new Ability
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    ability.Deserialize(data);
                    session.SetData(Data.AbilityPet, ability);
                    break;
                case 9:
                    var fellow = new Fellow()
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    fellow.Deserialize(data);
                    session.SetData(Data.Fellow, fellow);
                    break;
            }
        }

        return data;
    }

    private async Task<Packet> CosUpdate(SERVER_COS_UPDATE data, ISession session)
    {
        data.TryRead(out uint uniqueId)
            .TryRead(out byte type);

        session.GetData<Transport?>(Data.Transport, out var transport, null);
        session.GetData<JobTransport?>(Data.JobTransport, out var jobTransport, null);
        session.GetData<Ability?>(Data.AbilityPet, out var abilityPet, null);
        session.GetData<Growth?>(Data.Growth, out var growth, null);
        session.GetData<Fellow?>(Data.Fellow, out var fellow, null);

        if (growth?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.RemoveData(Data.Growth);
                    break;
                case 2: // update inventory
                    break;
                case 3:
                    data.TryRead(out long experience)
                        .TryRead(out uint source);
                    if (source == growth.UniqueId)
                        return data;

                    growth.Experience += experience;

                    var iLevel = growth.Level;
                    while (growth.Experience > Cache.GetRefLevelAsync(iLevel).Result.Exp_C)
                    {
                        growth.Experience -= Cache.GetRefLevelAsync(iLevel).Result.Exp_C;
                        iLevel++;
                    }

                    if (growth.Level < iLevel)
                    {
                        growth.Level = iLevel;
                    }

                    break;
                case 4:
                    data.TryRead(out growth.CurrentHungerPoints);
                    break;
                case 5:
                    data.TryRead(out growth.Name);
                    break;
                case 7:
                    data.TryRead(out growth.Id);
                    var record = growth.RefObjChar;
                    if (record != null)
                        growth.Health = growth.MaxHealth = record.MaxHP;
                    break;
                default:
                    break;
            }
        }

        if (fellow?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.RemoveData(Data.Fellow);
                    break;
                case 2: // update inventory
                    break;
                case 3:
                    data.TryRead(out long experience)
                        .TryRead(out uint source);
                    if (source == fellow.UniqueId)
                        return data;

                    fellow.Experience += experience;

                    var iLevel = fellow.Level;
                    while (fellow.Experience > Cache.GetRefLevelAsync(iLevel).Result.Exp_C)
                    {
                        fellow.Experience -= Cache.GetRefLevelAsync(iLevel).Result.Exp_C;
                        iLevel++;
                    }

                    if (fellow.Level < iLevel)
                    {
                        fellow.Level = iLevel;
                        fellow.MaxHealth = fellow.Health;
                    }

                    break;
                case 4:
                    data.TryRead(out fellow.Satiety);
                    break;
                case 5:
                    data.TryRead(out fellow.Name);
                    break;
                case 7:
                    data.TryRead(out fellow.Id);
                    var record = fellow.RefObjChar;
                    if (record != null)
                        fellow.Health = fellow.MaxHealth = record.MaxHP;
                    break;
                default:
                    break;
            }
        }

        if (abilityPet?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.RemoveData(Data.AbilityPet);
                    break;
                case 2:
                    abilityPet.Inventory.Deserialize(data);
                    break;
                case 5:
                    data.TryRead(out abilityPet.Name);
                    break;
            }
        }

        if (transport?.UniqueId == uniqueId)
        {
            session.RemoveData(Data.Transport);
        }

        if (jobTransport?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    session.RemoveData(Data.JobTransport);
                    break;
                case 2:
                    jobTransport.Inventory.Deserialize(data);
                    break;
            }
        }

        return data;
    }

    private async Task<Packet> CosUpdateRidestateResponse(SERVER_COS_UPDATE_RIDESTATE_RESPONSE data, ISession session)
    {
        data.TryRead(out byte result);
        if (result != 0x01)
        {
            return data;
        }

        data.TryRead(out uint ownerUniqueId)
            .TryRead(out bool isMounted)
            .TryRead(out uint cosUniqueId);

        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        if (charInfo == null)
        {
            return data;
        }

        if (ownerUniqueId != charInfo.UniqueCharId)
        {
            return data;
        }

        session.GetData<Transport?>(Data.Transport, out var transport, null);
        session.GetData<JobTransport?>(Data.JobTransport, out var jobTransport, null);
        session.GetData<Growth?>(Data.Growth, out var growth, null);
        session.GetData<Fellow?>(Data.Fellow, out var fellow, null);

        if (cosUniqueId == transport?.UniqueId)
            session.SetData(Data.Vehicle, transport);

        if (cosUniqueId == jobTransport?.UniqueId)
            session.SetData(Data.Vehicle, jobTransport);

        // Vsro private servers uses the attack pet like pet2
        if (cosUniqueId == growth?.UniqueId)
            session.SetData(Data.Vehicle, growth);

        if (cosUniqueId == fellow?.UniqueId)
            session.SetData(Data.Vehicle, fellow);

        charInfo.OnTransport = isMounted;
        charInfo.TransportUniqueId = cosUniqueId;

        if (!isMounted)
        {
            session.RemoveData(Data.Vehicle);
            session.RemoveData(Data.Transport);
            charInfo.TransportUniqueId = 0;
        }

        return data;
    }

    private async Task<Packet> EntityStateUpdate(SERVER_ENTITY_STATE_UPDATE data, ISession session)
    {
        data.TryRead(out uint uniqueId);
        session.GetData<ICharInfo?>(Data.CharInfo, out var charInfo, null);
        if (charInfo == null || charInfo.UniqueCharId != uniqueId) return data;

        data.TryRead(out byte updateType)
            .TryRead(out byte updateState);

        var countdownManager = session.GetCountdownManager();
        var timerManager = session.GetTimerManager();

        switch (updateType)
        {
            case 0:
                charInfo.State.LifeState = (LifeState)updateState;

                if ((LifeState)updateState == LifeState.Dead &&
                    countdownManager != null &&
                    countdownManager.IsStopOnDead() &&
                    countdownManager.IsStarted())
                {
                    countdownManager.Stop();
                }

                if (timerManager != null && timerManager.IsStarted())
                {
                    timerManager.Stop();
                }

                break;
            case 1:
                var motionState = (MotionState)updateState;
                charInfo.State.MotionState = motionState;

                charInfo.State.MovementType = motionState switch
                {
                    MotionState.Walking => MovementType.Walking,
                    MotionState.Running => MovementType.Running,
                    MotionState.StandUp => MovementType.None,
                    MotionState.Sitting => MovementType.None,
                    _ => throw new ArgumentOutOfRangeException()
                };

                break;
            case 4:
                charInfo.State.BodyState = (BodyState)updateState;
                break;

            case 7:
                charInfo.PvpState = (PvpState)updateState;
                break;
            case 8:
                charInfo.State.BattleState = (BattleState)updateState;
                if ((BattleState)updateState == BattleState.InBattle &&
                    timerManager != null &&
                    timerManager.IsStarted() &&
                    timerManager.IsStopOnBattle())
                {
                    timerManager.Stop();
                }

                break;
            case 11:
                charInfo.State.ScrollState = (ScrollState)updateState;
                break;

            default:
                Log.Error("{0} - EntityUpdate: Unknown update type {1} - State: {2}",
                    charInfo.CharName, updateType, updateState);
                break;
        }

        return data;
    }

    private async Task<Packet> CharacterDataBegin(SERVER_CHARACTER_DATA_BEGIN data, ISession session)
    {
        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        charInfo.Initialize();

        return data;
    }

    private async Task<Packet> CharacterData(SERVER_CHARACTER_DATA data, ISession session)
    {
        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        charInfo.Append(data);

        // data.ResultType = PacketResultType.Block;
        return data;
    }

    private async Task<Packet> CharacterDataEnd(SERVER_CHARACTER_DATA_END data, ISession session)
    {
        session.GetData(Data.CharInfo, out var charInfo, new CharInfo());
        var charPacket = charInfo.GetPacket();
        if (charPacket == null) return data;

        await charInfo.Read();
        // await session.SendToClient(charPacket);
        charInfo.Clear();

        return data;
    }

    private async Task<Packet> EntitySingleSpawn(SERVER_ENTITY_SPAWN data, ISession session)
    {
        session.GetData(Data.EntityInfo, out var entityInfo, new EntityInfo(session));
        entityInfo.Initialize(SpawnInfoType.Spawn, 1, 0x3015);
        entityInfo.Append(data);

        var entityPacket = entityInfo.GetPacket();
        if (entityPacket == null) return data;

        await entityInfo.ReadSpawn();
        await session.SendToClient(entityPacket);
        entityInfo.Clear();

        data.ResultType = PacketResultType.Block;
        return data;
    }

    private async Task<Packet> EntitySingleDespawn(SERVER_ENTITY_DESPAWN data, ISession session)
    {
        session.GetData(Data.EntityInfo, out var entityInfo, new EntityInfo(session));
        entityInfo.Initialize(SpawnInfoType.Despawn, 1, 0x3016);
        entityInfo.Append(data);

        var entityPacket = entityInfo.GetPacket();
        if (entityPacket == null) return data;

        await entityInfo.ReadDespawn();
        await session.SendToClient(entityPacket);
        entityInfo.Clear();

        data.ResultType = PacketResultType.Block;
        return data;
    }

    private async Task<Packet> EntityGroupSpawnBegin(SERVER_ENTITY_GROUPSPAWN_BEGIN data, ISession session)
    {
        session.GetData(Data.EntityInfo, out var entityInfo, new EntityInfo(session));
        entityInfo.Initialize(data.SpawnInfoType, data.Amount, 0x3019);
        
        return data;
    }

    private async Task<Packet> EntityGroupSpawnData(SERVER_ENTITY_GROUPSPAWN_DATA data, ISession session)
    {
        session.GetData(Data.EntityInfo, out var entityInfo, new EntityInfo(session));
        entityInfo.Append(data);

        // data.ResultType = PacketResultType.Block;
        return data;
    }

    private async Task<Packet> EntityGroupSpawnEnd(SERVER_ENTITY_GROUPSPAWN_END data, ISession session)
    {
        session.GetData(Data.EntityInfo, out var entityInfo, new EntityInfo(session));
        var entityPacket = entityInfo.GetPacket();
        if (entityPacket == null) return data;

        await entityInfo.Read();
        // await session.SendToClient(entityPacket);
        entityInfo.Clear();

        return data;
    }
}