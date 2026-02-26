using McMaster.NETCore.Plugins;

namespace API.Event;

public interface IEventManager : IDisposable
{
    Dictionary<PluginLoader, IEvent> Loaders { get; }

    bool IsLoaded(string name);

    /// <summary>Loads event from path: if path is a directory with event.json, uses that; otherwise treats path as DLL file.</summary>
    PluginLoader? LoadEvent(string path);

    IEvent StartEvent(PluginLoader pluginLoader);

    /// <summary>Starts the event and tracks folder name for "available" list (so loaded events are excluded from available).</summary>
    IEvent StartEvent(PluginLoader pluginLoader, string? folderName);

    /// <summary>Event folder names (subdirs of events/ with event.json) that are not currently loaded.</summary>
    IReadOnlyList<string> GetAvailableEventFolderNames();

    bool UnloadEvent(string name);

    bool UnloadEvent(IEvent eEvent);

    bool UnloadEvent(PluginLoader pluginLoader);

    string? SearchEvent(string directory, string eventName);

    /// <summary>Unloads the event by name and loads it again (e.g. after adding/removing cron entries).</summary>
    bool ReloadEvent(string name);
}