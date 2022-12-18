using System.Timers;

namespace API.Session;

public interface ICountdownManager
{
    void Start(int timeInSeconds, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, ElapsedEventHandler elapsedEventHandler);
    void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, bool stopOldTimer, ElapsedEventHandler elapsedEventHandler);
    void Stop();
    void Resend();
    bool IsStarted();
    bool IsStopOnDead();
    bool IsStopOnTeleport();
    TimeSpan LeftTime();
}