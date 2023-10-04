namespace API.Event;

public abstract class IEvent : IDisposable
{
    public abstract string Name { get; }
    public abstract string Version { get; }
    public abstract string Author { get; }

    protected IEventState[]? EventStates { get; set; }
    protected IEventState? CurrentEventState { get; set; }

    public abstract void Dispose();

    public abstract void OnEnable();

    public IEvent OnTimerTick()
    {
        StopCurrentGameState();
        SetEventState(EventStateEnum.Starting);

        return this;
    }

    protected IEvent AddEventState(IEventState eventState, EventStateEnum eventStateEnumEnum)
    {
        if (EventStates != null) EventStates[(int)eventStateEnumEnum] = eventState;
        return this;
    }

    public void SetEventState(EventStateEnum eventStateEnumEnum)
    {
        CurrentEventState?.Stop();
        CurrentEventState = EventStates?[(int)eventStateEnumEnum];
        CurrentEventState?.Start();
    }

    protected void StopCurrentGameState()
    {
        CurrentEventState?.Stop();
        CurrentEventState = null;
    }
}