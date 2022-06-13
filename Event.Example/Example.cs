using API.Event;

namespace Event.Quiz;

public class Example : IEvent
{
    public override string Name => "EventExample";
    public override string Version => "1.0.0";
    public override string Author => "b0ykoe";

    public override void OnEnable()
    {
        EventStates = new IEventState[Enum.GetNames(typeof(EventStateEnum)).Length];
        AddEventState(new ExampleStarting(this), EventStateEnum.Starting);
        AddEventState(new ExampleRunning(this), EventStateEnum.Running);
        AddEventState(new ExampleEnding(this), EventStateEnum.Ending);
    }

    public override void Dispose()
    {
        StopCurrentGameState();
        EventStates = null;
    }
}