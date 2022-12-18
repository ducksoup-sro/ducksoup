using System.Timers;

namespace API.Session;

public interface ITimerManager
{
    void Start(int timeInSeconds, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, bool broadcast, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnBattle, bool broadcast, bool stopOldTimer, ElapsedEventHandler elapsedEventHandler);
    void Stop();
    void Send(ISession session);
    bool IsStarted();
    bool IsBroadcast();
    bool IsStopOnBattle();
    TimeSpan leftTime();
}