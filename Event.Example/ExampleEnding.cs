using API;
using API.Event;
using API.ServiceFactory;

namespace Event.Quiz;

public class ExampleEnding : IEventState
{
    private readonly IEvent _event;
    
    public ExampleEnding(IEvent iEvent) : base(iEvent)
    {
        _event = iEvent;
    }
    
    public override Task Start()
    {
        Global.Logger.InfoFormat("{0}", this);
        foreach (var agentSession in ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).AgentSessions.Where(agentSession => agentSession.CharacterGameReady))
        {
            agentSession.SendNotice("Quiz starting in 10 Seconds");
        }
        Thread.Sleep(10 * 1000);
        return Task.CompletedTask;
    }

    public override Task Stop()
    {
        return Task.CompletedTask;
    }
}