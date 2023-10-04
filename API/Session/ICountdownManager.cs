namespace API.Session;

public interface ICountdownManager
{
    public delegate Task Action();

    void Start(int timeInSeconds, Action action);
    void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, Action action);
    void Start(int timeInSeconds, bool stopOnTeleport, bool stopOnDead, bool stopOldTimer, Action action);
    void Stop();
    void Resend();
    bool IsStarted();
    bool IsStopOnDead();
    bool IsStopOnTeleport();
    TimeSpan LeftTime();
}