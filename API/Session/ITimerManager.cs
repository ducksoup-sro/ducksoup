using PacketLibrary.Handler;

namespace API.Session;

public interface ITimerManager
{
    public delegate Task Action();
    void Start(int timeInSeconds, Action action);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, Action action);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, bool broadcast, Action action);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool stopOnVehicleMove, bool broadcast, bool stopOldTimer, Action action);
    void Stop();
    void Send(ISession session);
    bool IsStarted();
    bool IsBroadcast();
    bool IsStopOnBattle();
    bool IsStopOnMove();
    bool IsStopOnVehicleMove();
    TimeSpan leftTime();
}