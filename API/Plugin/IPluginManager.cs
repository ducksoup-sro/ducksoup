using McMaster.NETCore.Plugins;

namespace API.Plugin;

public interface IPluginManager : IDisposable
{
    Dictionary<PluginLoader, IPlugin> Loaders { get; }

    bool IsLoaded(string name);
    PluginLoader? LoadPlugin(string folder);
    IPlugin StartPlugin(PluginLoader pluginLoader);
    bool UnloadPlugin(string name);
    bool UnloadPlugin(IPlugin plugin);
    bool UnloadPlugin(PluginLoader pluginLoader);
    List<string> GetFilesInDirectory(string directory);
    string? SearchPluginDirectory(string directory, string pluginName);
}