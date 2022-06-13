using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API;
using API.Command;
using API.Plugin;
using API.ServiceFactory;
using DuckSoup.Library.Commands;
using DuckSoup.Library.Server;
using McMaster.NETCore.Plugins;

namespace DuckSoup.Library.Plugins;

public class PluginManager : IPluginManager
{
    public Dictionary<PluginLoader, IPlugin> Loaders { get; private set; }

    public PluginManager()
    {
        ServiceFactory.Register<IPluginManager>(typeof(IPluginManager), this);

        Loaders = new Dictionary<PluginLoader, IPlugin>();
        Setup();
    }

    public bool IsLoaded(string name)
    {
        foreach (var (_, value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
            {
                return true;
            }
        }

        return false;
    }

    public PluginLoader LoadPlugin(string file)
    {
        return PluginLoader.CreateFromAssemblyFile(Directory.GetCurrentDirectory() + "\\" + file,
            configure: config =>
            {
                config.IsUnloadable = true;
                config.LoadInMemory = true;
                config.PreferSharedTypes = true;
            });
    }

    public IPlugin StartPlugin(PluginLoader pluginLoader)
    {
        var commandManager = ServiceFactory.Load<ICommandManager>(typeof(ICommandManager));
        
        IPlugin plugin = null;
        foreach (var pluginType in pluginLoader
                     .LoadDefaultAssembly()
                     .GetTypes()
                     .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract))
        {
            // This assumes the implementation of IPlugin has a parameterless constructor
            plugin = (IPlugin) Activator.CreateInstance(pluginType)!;
            plugin.OnEnable();
            var tempPlugin = new InternalPluginCommand(plugin.Name, plugin.Name + " <command>", "");
            tempPlugin.AddCommands(plugin.RegisterCommands());
            commandManager._commands.Add(tempPlugin);
            Loaders.Add(pluginLoader, plugin);
        }

        return plugin;
    }

    public bool UnloadPlugin(string name)
    {
        var commandManager = ServiceFactory.Load<ICommandManager>(typeof(ICommandManager));
        var removePlugins = new Dictionary<PluginLoader, IPlugin>();
        var removeCommands = new List<Command>();
        
        foreach (var (key, value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
            {
                removePlugins.Add(key, value);
            }
        }

        foreach (var (_, value) in removePlugins)
        {
            removeCommands.AddRange(commandManager._commands.Where(commandManagerCommand => commandManagerCommand.GetName().Equals(value.Name)));
            foreach (var removeCommand in removeCommands)
            {
                commandManager._commands.Remove(removeCommand);
            }
            return UnloadPlugin(value);
        }

        return false;
    }

    public bool UnloadPlugin(IPlugin plugin)
    {
        foreach (var (key, value) in Loaders)
        {
            if (!value.Name.ToLower().Equals(plugin.Name.ToLower()))
            {
                continue;
            }
    
            plugin.Dispose();
            key.Dispose();
            return UnloadPlugin(key);
        }
    
        return false;
    }
    
    public bool UnloadPlugin(PluginLoader pluginLoader)
    {
        pluginLoader.Dispose();
        Loaders.Remove(pluginLoader);
        var check = !Loaders.ContainsKey(pluginLoader);
        return check;
    }

    public List<string> GetFilesInDirectory(string directory)
    {
        return !Directory.Exists(directory)
            ? null
            : Directory.GetFiles(directory).Where(file => file.EndsWith(".dll")).ToList();
    }

    public string SearchPlugin(string directory, string pluginName)
    {
        if (!Directory.Exists(directory))
        {
            return null;
        }

        foreach (var file in Directory.GetFiles(directory))
        {
            if (!file.EndsWith(".dll"))
            {
                continue;
            }

            var replace = file.ToLower().Replace("plugin.", "").Replace(".dll", "").Replace(directory, "")
                .Replace("\\", "");
            var searchName = pluginName.Replace("plugin.", "").Replace(".dll", "");

            if (replace.ToLower().Equals(searchName.ToLower()))
            {
                return file;
            }
        }

        return null;
    }

    private void Setup()
    {
        Global.Logger.InfoFormat("Loading plugins..");
        var pluginFiles = GetFilesInDirectory("plugins");
        if (pluginFiles == null)
        {
            Global.Logger.InfoFormat("No pluginfolder found. Creating one..");
            Directory.CreateDirectory("plugins");
            return;
        }

        var temp = new List<PluginLoader>();
        foreach (var file in pluginFiles)
        {
            temp.Add(LoadPlugin(file));
            Global.Logger.InfoFormat("Plugin: {0} loaded.", file.Replace("\\plugins", ""));
        }

        Global.Logger.InfoFormat("Starting plugins..");
        foreach (var pluginLoader in temp)
        {
            var plugin = StartPlugin(pluginLoader);
            Global.Logger.InfoFormat("Plugin: {0} ({1}) by [{2}] started.", plugin.Name, plugin.Version, plugin.Author);
        }
    }

    public void Dispose()
    {
        foreach (var (_, value) in Loaders)
        {
            value.Dispose();
        }

        Loaders = null;
    }
}