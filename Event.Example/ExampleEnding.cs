using API;
using API.Event;
using API.ServiceFactory;
using API.Session;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;

namespace Event.Quiz;

public class ExampleEnding : IEventState
{
    private readonly IEvent _event;
    private readonly ISharedObjects _sharedObjects;
    public ExampleEnding(IEvent iEvent) : base(iEvent)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        _event = iEvent;
    }
    
    public override Task Start()
    {
        Global.Logger.InfoFormat("{0}", this);
        foreach (var agentSession in _sharedObjects.AgentSessions.Where(agentSession =>
                 {
                     agentSession.GetData<bool>(SessionConst.CHARACTER_GAME_READY, out var characterGameReady);
                     return characterGameReady;
                 }))
        {
            agentSession.SendToClient(SERVER_CHAT_UPDATE.of(ChatType.Notice, "Quiz cleanup in 10 Seconds"));
        }
        Thread.Sleep(10 * 1000);
        return Task.CompletedTask;
    }

    public override Task Stop()
    {
        return Task.CompletedTask;
    }
}