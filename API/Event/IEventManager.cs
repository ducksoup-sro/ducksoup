using McMaster.NETCore.Plugins;

namespace API.Event;

public interface IEventManager : IDisposable
{
    Dictionary<PluginLoader, IEvent> Loaders { get; }

    bool IsLoaded(string name);

    PluginLoader LoadEvent(string file);

    IEvent StartEvent(PluginLoader pluginLoader);

    bool UnloadEvent(string name);

    bool UnloadEvent(IEvent eEvent);

    bool UnloadEvent(PluginLoader pluginLoader);

    string? SearchEvent(string directory, string eventName);
}