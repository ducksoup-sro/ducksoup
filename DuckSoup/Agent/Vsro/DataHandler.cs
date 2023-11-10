using System;
using System.Threading.Tasks;
using API.EventFactory;
using API.Extensions;
using API.Session;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Client;
using PacketLibrary.VSRO188.Agent.Objects;
using PacketLibrary.VSRO188.Agent.Objects.Cos;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent.Vsro;

public class DataHandler
{
    public DataHandler(IPacketHandler packetHandler)
    {
        packetHandler.RegisterClientHandler<CLIENT_GAME_READY>(CLIENT_GAME_READY);
        packetHandler.RegisterModuleHandler<SERVER_MOVEMENT_RESPONSE>(SERVER_MOVEMENT);
        packetHandler.RegisterModuleHandler<SERVER_ENTITY_POSITION_UPDATE>(SERVER_ENTITY_POSITION_UPDATE);
        packetHandler.RegisterModuleHandler<SERVER_TELEPORT_USE_RESPONSE>(SERVER_TELEPORT_USE_RESPONSE);
    }

    private async Task<Packet> CLIENT_GAME_READY(CLIENT_GAME_READY data, ISession session)
    {
        session.GetData(Data.CharScreen, out var charScreen, true);
        session.SetData(Data.CharacterGameReady, true);
        session.SetData(Data.CharacterGameReadyTimestamp, DateTime.Now.ToUnixTimeMilliseconds());
        session.GetData(Data.FirstSpawn, out var firstSpawn, false);

        if (charScreen)
        {
            EventFactory.Publish(EventFactoryNames.OnUserLeaveCharScreen, session);
            session.SetData(Data.CharScreen, false);
        }

        if (!firstSpawn)
        {
            session.SetData(Data.FirstSpawn, true);
            EventFactory.Publish(EventFactoryNames.OnCharacterFirstSpawn, session);
        }

        EventFactory.Publish(EventFactoryNames.OnCharacterGameReadyChange, session, true);

        var countdownManager = session.GetCountdownManager();
        if (countdownManager != null && countdownManager.IsStarted())
        {
            if (!countdownManager.IsStopOnTeleport())
                countdownManager.Resend();
            else
                countdownManager.Stop();
        }

        var timerManager = session.GetTimerManager();
        if (timerManager != null && timerManager.IsStarted()) timerManager.Stop();

        return data;
    }
    
    private async Task<Packet> SERVER_ENTITY_POSITION_UPDATE(SERVER_ENTITY_POSITION_UPDATE data, ISession session)
    {
        session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        if (charInfo == null) return data;

        if (data.EntityId != charInfo.UniqueCharId) return data;

        charInfo.CurPosition = data.Position;
        charInfo.TargetPosition = new Position(0, 0);
        return data;
    }

    private async Task<Packet> SERVER_MOVEMENT(SERVER_MOVEMENT_RESPONSE data, ISession session)
    {
        session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        session.GetData(Data.Vehicle, out Cos? vehicle, null);
        
        if (charInfo == null || data.TargetId != charInfo.UniqueCharId &&
            (vehicle == null || vehicle.UniqueId != data.TargetId))
        {
            return data;
        }
        
        charInfo.LastPositionUpdate = DateTime.UtcNow.ToUnixTimeMilliseconds();
        if (data.Movement.HasSource) charInfo.CurPosition = data.Movement.Source;

        if (data.Movement.HasDestination) {
            charInfo.TargetPosition = data.Movement.Destination;
        } else {
            charInfo.TargetPosition = new Position(0, 0);
        }
        
        var timerManager = session.GetTimerManager();
        if (timerManager == null)
        {
            return data;
        }
        
        if (timerManager.IsStarted() && timerManager.IsStopOnMove() &&
            data.TargetId == charInfo.UniqueCharId)
        {
            timerManager.Stop();
        }

        if (timerManager.IsStarted() && timerManager.IsStopOnVehicleMove() &&
            vehicle != null && vehicle.UniqueId == data.TargetId)
        {
            timerManager.Stop();
        }
        
        return data;
    }
    
    private async Task<Packet> SERVER_TELEPORT_USE_RESPONSE(SERVER_TELEPORT_USE_RESPONSE data, ISession session)
    {
        session.SetData(Data.CharacterGameReady, false);
        session.SetData(Data.CharacterGameReadyTimestamp, 0);
        EventFactory.Publish(EventFactoryNames.OnCharacterGameReadyChange, session, false);
        
        var countdownManager = session.GetCountdownManager();
        if (countdownManager != null && countdownManager.IsStarted() && countdownManager.IsStopOnTeleport())
        {
            countdownManager.Stop();
        }

        var timerManager = session.GetTimerManager();
        if (timerManager != null && timerManager.IsStarted())
        {
            timerManager.Stop();
        }

        return data;
    }
}