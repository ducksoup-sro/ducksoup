using API.Command;
using API.Event;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Event;

public class EventUnloadCommand : Command
{
    private IEventManager _eventManager;

    public EventUnloadCommand() : base("unload", "event unload <name>", "Unloads a given event", new[] { "ul" })
    {
    }

    public override void Execute(string[]? args)
    {
        _eventManager ??= ServiceFactory.Load<IEventManager>(typeof(IEventManager));

        if (args.Length == 0 || args[0].Replace(" ", "") == "" || !_eventManager.IsLoaded(args[0])) return;

        Log.Information(
            _eventManager.UnloadEvent(args[0]) ? "Event: {0} unloaded" : "Error while unloading event {0}.",
            args[0]);
    }
}