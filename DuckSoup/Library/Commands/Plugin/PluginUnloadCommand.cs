using System.Collections.Generic;
using API;
using API.Command;
using API.Plugin;
using API.ServiceFactory;
using McMaster.NETCore.Plugins;

namespace DuckSoup.Library.Commands.Plugin;

public class PluginUnloadCommand : Command
{
    private IPluginManager _pluginManager;

    public PluginUnloadCommand() : base("unload", "plugin unload <name>", "Unloads a given plugin", new []{"ul"})
    {
    }

    public override void Execute(string[]? args)
    {
        _pluginManager ??= ServiceFactory.Load<IPluginManager>(typeof(IPluginManager));

        if (args.Length == 0 || args[0].Replace(" ", "") == "" || !_pluginManager.IsLoaded(args[0]))
        {
            return;
        }

        Global.Logger.InfoFormat(
            _pluginManager.UnloadPlugin(args[0]) ? "Plugin: {0} unloaded" : "Error while unloading plugin {0}.",
            args[0]);
    }
}