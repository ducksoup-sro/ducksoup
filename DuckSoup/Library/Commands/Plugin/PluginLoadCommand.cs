using System.Collections.Generic;
using System.Linq;
using API;
using API.Command;
using API.Plugin;
using API.ServiceFactory;

namespace DuckSoup.Library.Commands.Plugin;

public class PluginLoadCommand : Command
{
    private IPluginManager _pluginManager;

    public PluginLoadCommand() : base("load", "plugin load <name>", "Loads a given plugin", new []{"l"})
    {
    }

    public override void Execute(string[]? args)
    {
        _pluginManager ??= ServiceFactory.Load<IPluginManager>(typeof(IPluginManager));

        if (args.Length == 0 || args[0].Replace(" ", "") == "" || _pluginManager.IsLoaded(args[0]))
        {
            return;
        }

        var pluginList = _pluginManager.SearchPlugin("plugins", args[0]);
        if (pluginList == null)
        {
            Global.Logger.InfoFormat("No plugin found named {0}", args[0]);
            return;
        }
        
        var plugin = _pluginManager.StartPlugin(_pluginManager.LoadPlugin(pluginList));

        Global.Logger.InfoFormat(
            plugin != null ? "Plugin: {0} ({1}) by [{2}] started." : "Error while loading plugin {0}.", plugin.Name,
            plugin.Version, plugin.Author);
    }
}