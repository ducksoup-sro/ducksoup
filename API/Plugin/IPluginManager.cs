using McMaster.NETCore.Plugins;

namespace API.Plugin;

public interface IPluginManager : IDisposable
{
    Dictionary<PluginLoader, IPlugin> Loaders { get; }

    bool IsLoaded(string name);

    PluginLoader? LoadPlugin(string folder);

    IPlugin StartPlugin(PluginLoader pluginLoader);

    /// <summary>Start plugin and associate it with the given folder name (so loaded vs available can be matched).</summary>
    IPlugin StartPlugin(PluginLoader pluginLoader, string? folderName);

    bool UnloadPlugin(string name);

    bool UnloadPlugin(IPlugin plugin);

    bool UnloadPlugin(PluginLoader pluginLoader);

    List<string> GetFilesInDirectory(string directory);

    string? SearchPluginDirectory(string directory, string pluginName);

    /// <summary>Returns loaded plugins with their folder name (when known). Used to match loaded vs available by folder.</summary>
    IReadOnlyList<LoadedPluginInfo> GetLoadedPluginInfos();
}