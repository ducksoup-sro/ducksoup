using API.Webserver;

namespace API.Event;

public abstract class IEvent : IDisposable
{
    public abstract string Name { get; }
    public abstract string Version { get; }
    public abstract string Author { get; }

    protected IEventState[]? EventStates { get; set; }
    protected IEventState? CurrentEventState { get; set; }

    /// <summary>Returns the current state enum by matching CurrentEventState to the EventStates array.</summary>
    public EventStateEnum? GetCurrentState()
    {
        if (CurrentEventState == null || EventStates == null) return null;
        for (var i = 0; i < EventStates.Length; i++)
        {
            if (EventStates[i] == CurrentEventState)
                return (EventStateEnum)i;
        }
        return null;
    }

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

    /// <summary>Called when the dashboard triggers "reload settings". Override in event to re-read config.</summary>
    public virtual void InitSettings() { }

    /// <summary>Menu routes for this event (shown under Events in the dashboard). Same type as plugin routes for unified webserver handling.</summary>
    public virtual IReadOnlyList<IWebserverPluginRoute> GetMenuRoutes() => Array.Empty<IWebserverPluginRoute>();
}