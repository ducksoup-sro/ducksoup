using System.IO;
using API.Command;
using API.Event;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Event;

public class EventLoadCommand : Command
{
    private IEventManager _eventManager;

    public EventLoadCommand() : base("load", "event load <name>", "Loads a given event", new[]
    {
        "l"
    })
    {
    }

    public override void Execute(string[]? args)
    {
        _eventManager ??= ServiceFactory.Load<IEventManager>(typeof(IEventManager));

        if (args.Length == 0 || args[0].Replace(" ", "") == "" || _eventManager.IsLoaded(args[0])) return;

        string? folderPath = _eventManager.SearchEvent("events", args[0]);
        if (folderPath == null)
        {
            Log.Information("No Event found named {0} (need folder with event.json in events/)", args[0]);
            return;
        }

        var loader = _eventManager.LoadEvent(folderPath);
        if (loader == null)
        {
            Log.Warning("Failed to load event from {0}", folderPath);
            return;
        }

        var folderName = Path.GetFileName(folderPath);
        IEvent? eEvent = _eventManager.StartEvent(loader, folderName);

        Log.Information(
            eEvent != null ? "Event: {0} ({1}) by [{2}] started." : "Error while loading event {0}.", eEvent?.Name ?? args[0],
            eEvent?.Version ?? "", eEvent?.Author ?? "");
    }
}