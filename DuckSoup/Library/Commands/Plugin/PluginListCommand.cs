using API.Command;
using API.Plugin;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Plugin;

public class PluginListCommand : Command
{
    private IPluginManager _pluginManager;

    public PluginListCommand() : base("list", "plugin list", "Shows a list of all loaded plugins", new[] { "ls" })
    {
    }

    public override void Execute(string[]? args)
    {
        _pluginManager ??= ServiceFactory.Load<IPluginManager>(typeof(IPluginManager));

        Log.Information("Plugins[{0}]: ", _pluginManager.Loaders.Count);
        foreach (var (_, value) in _pluginManager.Loaders)
            Log.Information("Plugin: {0} ({1}) by [{2}]", value.Name, value.Version,
                value.Author);
    }
}