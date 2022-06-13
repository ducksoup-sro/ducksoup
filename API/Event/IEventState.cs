namespace API.Event;

public abstract class IEventState
{
    protected IEventState(IEvent iEvent)
    {
    }

    public abstract Task Start();
    public abstract Task Stop();
}