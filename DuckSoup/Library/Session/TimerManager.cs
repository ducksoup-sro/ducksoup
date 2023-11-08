using System;
using System.Threading.Tasks;
using System.Timers;
using API;
using API.Session;
using PacketLibrary.Handler;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Library.Session;

public class TimerManager : ITimerManager
{
    private readonly ISession _session;
    private bool _broadcast;
    private DateTime? _started;
    private bool _stopOnBattle;
    private bool _stopOnMove;
    private bool _stopOnVehicleMoveMove;
    private Timer? _timer;
    private int _timerInterval;

    public TimerManager(ISession session)
    {
        _timerInterval = -1;
        _session = session;
        _stopOnBattle = true;
        _stopOnMove = true;
        _stopOnVehicleMoveMove = true;
    }

    public void Start(int timeInSeconds, ITimerManager.Action action)
    {
        Start(timeInSeconds, true, true, true, action);
    }

    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove,
        ITimerManager.Action action)
    {
        Start(timeInSeconds, stopOnBattle, stopOnMove, stopOnVehicleMove, true, action);
    }

    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, bool broadcast,
        ITimerManager.Action action)
    {
        Start(timeInSeconds, stopOnBattle, stopOnMove, stopOnVehicleMove, broadcast, true, action);
    }

    public void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, bool broadcast,
        bool stopOldTimer, ITimerManager.Action action)
    {
        if (stopOldTimer && IsStarted()) Stop();

        timeInSeconds *= 1000;

        _stopOnBattle = stopOnBattle;
        _stopOnMove = stopOnMove;
        _stopOnVehicleMoveMove = stopOnVehicleMove;
        _broadcast = broadcast;
        _timerInterval = timeInSeconds;
        _timer = new Timer();
        _timer.Interval = 100;
        _timer.AutoReset = true;
        _timer.Elapsed += (_, _) =>
        {
            if (_started.GetValueOrDefault().AddMilliseconds(_timerInterval).Subtract(DateTime.Now).TotalMilliseconds >
                0) return;
            Task.Run(async () =>
            {
                Stop();
                await action();
                return Task.CompletedTask;
            });
        };
        _timer.Start();
        _started = DateTime.Now;

        var packet = CreateStartPacket();
        if (packet == null) return;

        if (!broadcast)
        {
            _session.SendToClient(packet);
            return;
        }

        Task.Run(async () => { await Helper.BroadcastPacket(packet); });
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
        if (packet == null) return;

        if (!_broadcast)
        {
            _session.SendToClient(packet);
            return;
        }

        Task.Run(async () => { await Helper.BroadcastPacket(packet); });
    }

    public void Send(ISession session)
    {
        var packet = CreateStartPacket();
        if (packet == null) return;

        session.SendToClient(packet);
    }

    public bool IsStarted()
    {
        return _timer != null && _started != null && _timerInterval != -1 &&
               _started.GetValueOrDefault().AddMilliseconds(_timerInterval) >= DateTime.Now;
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
        if (!IsStarted()) return TimeSpan.FromSeconds(0);

        return TimeSpan.FromSeconds(_started.GetValueOrDefault().AddSeconds(_timerInterval).Subtract(DateTime.Now)
            .TotalSeconds);
    }

    private Packet? CreateStartPacket()
    {
        _session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        if (charInfo == null) return null;

        var packetTime = (int)_started.GetValueOrDefault().AddMilliseconds(_timerInterval).Subtract(DateTime.Now)
            .TotalSeconds;
        var response = new Packet(0x3041);
        response.TryWrite(charInfo.UniqueCharId)
            .TryWrite<byte>(0x02)
            .TryWrite<byte>(0x02)
            .TryWrite((byte)packetTime);

        return response;
    }

    private Packet? CreateStopPacket()
    {
        _session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        if (charInfo == null) return null;

        var response = new Packet(0x3042);
        response.TryWrite(charInfo.UniqueCharId)
            .TryWrite<byte>(0x01);
        return response;
    }

    public void Send()
    {
        Send(_session);
    }
}