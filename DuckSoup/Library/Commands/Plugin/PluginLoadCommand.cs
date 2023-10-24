using API.Command;
using API.Plugin;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Plugin;

public class PluginLoadCommand : Command
{
    private IPluginManager _pluginManager;

    public PluginLoadCommand() : base("load", "plugin load <name>", "Loads a given plugin", new[] { "l" })
    {
    }

    public override void Execute(string[]? args)
    {
        _pluginManager ??= ServiceFactory.Load<IPluginManager>(typeof(IPluginManager));

        if (args.Length == 0 || args[0].Replace(" ", "") == "" || _pluginManager.IsLoaded(args[0])) return;

        var pluginList = _pluginManager.SearchPluginDirectory("plugins", args[0]);
        if (pluginList == null)
        {
            Log.Information("No plugin found named {0}", args[0]);
            return;
        }

        var pluginLoader = _pluginManager.LoadPlugin(pluginList);

        if (pluginLoader == null)
        {
            Log.Information("Couldn't load plugin {0}", args[0]);
            return;
        }
        
        var plugin = _pluginManager.StartPlugin(pluginLoader);

        Log.Information(
            plugin != null ? "Plugin: {0} ({1}) by [{2}] started." : "Error while loading plugin {0}.", plugin.Name,
            plugin.Version, plugin.Author);
    }
}