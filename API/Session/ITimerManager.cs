using System.Timers;

namespace API.Session;

public interface ITimerManager
{
    void Start(int timeInSeconds, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool broadcast, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, bool stopOnMove, bool broadcast, bool stopOldTimer, ElapsedEventHandler elapsedEventHandler);
    void Stop();
    void Send(ISession session);
    bool IsStarted();
    bool IsBroadcast();
    bool IsStopOnBattle();
    bool IsStopOnMove();
    TimeSpan leftTime();
}