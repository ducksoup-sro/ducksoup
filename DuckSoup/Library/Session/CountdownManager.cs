using System;
using System.Timers;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Session;

public class CountdownManager : ICountdownManager
{
    private bool _stopOnDead;
    private bool _stopOnTeleport;
    private Timer _timer;
    private DateTime? _started;
    private int _timerInterval;
    private readonly ISession _session;

    public CountdownManager(ISession session)
    {
        _timerInterval = -1;
        _session = session;
        _stopOnDead = true;
        _stopOnTeleport = true;
    }

    public void Start(int timeInSeconds, ElapsedEventHandler elapsedEventHandler)
    {
        Start(timeInSeconds, true, true, elapsedEventHandler);
    }
    
    public void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, ElapsedEventHandler elapsedEventHandler)
    {
        Start(timeInSeconds, stopOnTeleport, stopOnDead, true, elapsedEventHandler);
    }

    
    public void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, bool stopOldTimer, ElapsedEventHandler elapsedEventHandler)
    {
        if(stopOldTimer) {
            Stop();
        }
        
        timeInSeconds *= 1000;
        
        if (timeInSeconds> 1200000)
        {
            timeInSeconds = 1200000;
        }

        _stopOnDead = stopOnDead;
        _stopOnTeleport = stopOnTeleport;
        _timerInterval = timeInSeconds ;
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

        _session.SendToClient(CreateStartPacket());
    }

    public void Resend()
    {
        _session.SendToClient(CreateStartPacket());
    }
    
    
    private Packet CreateStartPacket()
    {
        var packetTime = 1200000 - (int) _started.GetValueOrDefault().AddMilliseconds(_timerInterval).Subtract(DateTime.Now).TotalMilliseconds;
        
        var response = new Packet(0x34B1, false, false);
        response.WriteUInt8(0xFF);
        response.WriteUInt8(0x0E);
        response.WriteUInt32(packetTime);

        return response;
    }

    private static Packet createStopPacket()
    {
        var response = new Packet(0x34B1, false, false);
        response.WriteByte(0x05);

        return response;
    }
    
    public void Stop()
    {
        _timer?.Stop();
        _timer = null;
        _started = null;
        _timerInterval = -1;
        _stopOnDead = true;
        _stopOnTeleport = true;
        
        _session.SendToClient(createStopPacket());
    }

    public bool IsStarted()
    {
        return _timer != null && _started != null && _timerInterval != -1 && _started.GetValueOrDefault().AddSeconds(_timerInterval) >= DateTime.Now;
    }

    public bool IsStopOnTeleport()
    {
        return _stopOnTeleport;
    }

    public bool IsStopOnDead()
    {
        return _stopOnDead;
    }

    public TimeSpan LeftTime()
    {
        if (!IsStarted())
        {
            return TimeSpan.FromSeconds(0);
        }

        return TimeSpan.FromSeconds(_started.GetValueOrDefault().AddSeconds(_timerInterval).Subtract(DateTime.Now).TotalSeconds);
    }
}