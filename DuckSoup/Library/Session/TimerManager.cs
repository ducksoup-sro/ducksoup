using System;
using System.Linq;
using System.Timers;
using API;
using API.ServiceFactory;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Session;

public class TimerManager : ITimerManager
{
    private bool _broadcast;
    private bool _stopOnBattle;
    private bool _stopOnMove;
    private bool _stopOnVehicleMoveMove;
    private Timer _timer;
    private DateTime? _started;
    private int _timerInterval;
    private readonly ISession _session;
    public TimerManager(ISession session)
    {
        _timerInterval = -1;
        _session = session;
        _stopOnBattle = true;
        _stopOnMove = true;
        _stopOnVehicleMoveMove = true;
    }

    public void Start(int timeInSeconds, ElapsedEventHandler elapsedEventHandler)
    {
        Start(timeInSeconds, true, true, true, elapsedEventHandler);
    }
    
    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, ElapsedEventHandler elapsedEventHandler)
    {
        Start(timeInSeconds, stopOnBattle, stopOnMove,  stopOnVehicleMove, true, elapsedEventHandler);
    }
    
    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove,bool broadcast, ElapsedEventHandler elapsedEventHandler)
    {
        Start(timeInSeconds, stopOnBattle, stopOnMove, stopOnVehicleMove, broadcast, true, elapsedEventHandler);
    }

    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove,bool broadcast, bool stopOldTimer, ElapsedEventHandler elapsedEventHandler)
    {
        if(stopOldTimer && IsStarted()) {
            Stop();
        }
        
        timeInSeconds *= 1000;

        _stopOnBattle = stopOnBattle;
        _stopOnMove = stopOnMove;
        _stopOnVehicleMoveMove = stopOnVehicleMove;
        _broadcast = broadcast;
        _timerInterval = timeInSeconds;
        _timer = new Timer();
        _timer.Interval = timeInSeconds;
        _timer.AutoReset = false;
        _timer.Elapsed += elapsedEventHandler;
        _timer.Elapsed += (_, _) =>
        {
            Stop();
        };
        _timer.Start();
        _started = DateTime.Now;

        var packet = CreateStartPacket();
        
        if (!broadcast)
        {
            _session.SendToClient(packet);
            return;
        }

        foreach (var agentSession in ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).AgentSessions.Where(agentSession => agentSession.CharacterGameReady))
        {
            agentSession.SendToClient(packet);
        }
    }

    public void Stop()
    {
        _timer?.Stop();
        _timer = null;
        _started = null;
        _timerInterval = -1;
        _broadcast = true;
        _stopOnBattle = true;
        _stopOnMove = true;
        _stopOnVehicleMoveMove = true;
        
        var packet = CreateStopPacket();

        if (!_broadcast)
        {
            _session.SendToClient(packet);
            return;
        }

        foreach (var agentSession in ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).AgentSessions.Where(agentSession => agentSession.CharacterGameReady))
        {
            agentSession.SendToClient(packet);
        }
    }
    
    private Packet CreateStartPacket()
    {
        var packetTime = (int) _started.GetValueOrDefault().AddMilliseconds(_timerInterval).Subtract(DateTime.Now).TotalSeconds;
        var response = new Packet(0x3041, false, false);
        response.WriteUInt32(_session.SessionData.UniqueCharId);
        response.WriteUInt8(0x02);
        response.WriteUInt8(0x02);
        response.WriteUInt8(packetTime);

        return response;
    }

    private Packet CreateStopPacket()
    {
        var response = new Packet(0x3042, false, false);
        response.WriteUInt32(_session.SessionData.UniqueCharId);
        response.WriteUInt8(0x01);

        return response;
    }

    public void Send()
    {
        Send(_session);
    }

    public void Send(ISession session)
    {
        session.SendToClient(CreateStartPacket());
    }

    public bool IsStarted()
    {
        return _timer != null && _started != null && _timerInterval != -1 && _started.GetValueOrDefault().AddMilliseconds(_timerInterval) >= DateTime.Now;
    }

    public bool IsBroadcast()
    {
        return _broadcast;
    }
    
    public bool IsStopOnBattle()
    {
        return _stopOnBattle;
    }
    
    public bool IsStopOnMove()
    {
        return _stopOnMove;
    }
    
    public bool IsStopOnVehicleMove()
    {
        return _stopOnVehicleMoveMove;
    }
    
    public TimeSpan leftTime()
    {
        if (!IsStarted())
        {
            return TimeSpan.FromSeconds(0);
        }

        return TimeSpan.FromSeconds(_started.GetValueOrDefault().AddSeconds(_timerInterval).Subtract(DateTime.Now).TotalSeconds);
    }
}