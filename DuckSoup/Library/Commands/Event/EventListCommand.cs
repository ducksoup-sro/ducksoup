using API.Command;
using API.Event;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Event;

public class EventListCommand : Command
{
    private IEventManager _eventManager;

    public EventListCommand() : base("list", "event list", "Shows a list of all loaded events", new[] { "ls" })
    {
    }

    public override void Execute(string[]? args)
    {
        _eventManager ??= ServiceFactory.Load<IEventManager>(typeof(IEventManager));

        Log.Information("Events[{0}]: ", _eventManager.Loaders.Count);
        foreach (var (_, value) in _eventManager.Loaders)
            Log.Information("Event: {0} ({1}) by [{2}]", value.Name, value.Version,
                value.Author);
    }
}