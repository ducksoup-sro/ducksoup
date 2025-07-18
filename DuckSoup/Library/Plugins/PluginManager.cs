using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Command;
using API.Plugin;
using API.ServiceFactory;
using DuckSoup.Library.Commands;
using McMaster.NETCore.Plugins;
using Newtonsoft.Json;
using Serilog;
using PluginConfig = API.Plugin.PluginConfig;

namespace DuckSoup.Library.Plugins;

public class PluginManager : IPluginManager
{
    public PluginManager()
    {
        ServiceFactory.Register<IPluginManager>(typeof(IPluginManager), this);

        Loaders = new Dictionary<PluginLoader, IPlugin>();
        Setup();
    }

    public Dictionary<PluginLoader, IPlugin> Loaders { get; private set; }

    public bool IsLoaded(string name)
    {
        foreach ((PluginLoader _, IPlugin value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
                return true;
        }

        return false;
    }

    public PluginLoader? LoadPlugin(string folder)
    {
        return LoadPlugin(folder, false);
    }

    public IPlugin StartPlugin(PluginLoader pluginLoader)
    {
        ICommandManager commandManager = ServiceFactory.Load<ICommandManager>(typeof(ICommandManager));

        IPlugin plugin = null;
        foreach (Type pluginType in pluginLoader
                     .LoadDefaultAssembly()
                     .GetTypes()
                     .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsAbstract))
        {
            // This assumes the implementation of IPlugin has a parameterless constructor
            plugin = (IPlugin)Activator.CreateInstance(pluginType)!;
            plugin.OnEnable();
            InternalPluginCommand tempPlugin = new InternalPluginCommand(plugin.Name, plugin.Name + " <command>", "");
            tempPlugin.AddCommands(plugin.RegisterCommands());
            commandManager._commands.Add(tempPlugin);
            Loaders.Add(pluginLoader, plugin);
        }

        return plugin;
    }

    public bool UnloadPlugin(string name)
    {
        ICommandManager commandManager = ServiceFactory.Load<ICommandManager>(typeof(ICommandManager));
        Dictionary<PluginLoader, IPlugin> removePlugins = new Dictionary<PluginLoader, IPlugin>();
        List<Command> removeCommands = new List<Command>();

        foreach ((PluginLoader key, IPlugin value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
                removePlugins.Add(key, value);
        }

        foreach ((PluginLoader _, IPlugin value) in removePlugins)
        {
            removeCommands.AddRange(commandManager._commands.Where(commandManagerCommand =>
                commandManagerCommand.GetName().Equals(value.Name)));
            foreach (Command removeCommand in removeCommands)
            {
                commandManager._commands.Remove(removeCommand);
            }
            return UnloadPlugin(value);
        }

        return false;
    }

    public bool UnloadPlugin(IPlugin plugin)
    {
        foreach ((PluginLoader key, IPlugin value) in Loaders)
        {
            if (!value.Name.ToLower().Equals(plugin.Name.ToLower())) continue;

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
        bool check = !Loaders.ContainsKey(pluginLoader);
        return check;
    }

    public List<string> GetFilesInDirectory(string directory)
    {
        return !Directory.Exists(directory)
            ? null
            : Directory.GetFiles(directory).Where(file => file.EndsWith(".dll")).ToList();
    }

    public string SearchPluginDirectory(string directory, string pluginName)
    {
        if (!Directory.Exists(directory)) return null;

        foreach (string folder in Directory.GetDirectories(directory))
        {
            string pluginFolder = $"{directory}{Path.DirectorySeparatorChar}{pluginName}";
            if (folder.ToLower().Equals(pluginFolder.ToLower())) return folder;
        }

        return null;
    }

    public void Dispose()
    {
        foreach ((PluginLoader _, IPlugin value) in Loaders)
        {
            value.Dispose();
        }

        Loaders = null;
    }

    public PluginLoader? LoadPlugin(string folder, bool setup)
    {
        string configFile = Path.Combine(folder, "plugin.json");
        if (!File.Exists(configFile))
        {
            Log.Warning("No plugin.json found in: {0}", folder);
            return null;
        }

        string configJson = File.ReadAllText(configFile);
        PluginConfig? config = JsonConvert.DeserializeObject<PluginConfig>(configJson);

        if (setup && !config.AutoStart)
        {
            Log.Warning("Plugin: {0} should not be autostarted.", folder);
            return null;
        }

        if (config == null)
        {
            Log.Warning("plugin.json was faulty in: {0}", folder);
            return null;
        }

        string absoluteMainLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), folder, config.MainLibrary);
        return PluginLoader.CreateFromAssemblyFile(absoluteMainLibraryPath,
            loaderConfig =>
            {
                loaderConfig.PreferSharedTypes = true;
                loaderConfig.IsUnloadable = true;
                loaderConfig.LoadInMemory = true;
            });
    }

    private void Setup()
    {
        Log.Information("Loading plugins..");
        if (!Directory.Exists("plugins"))
        {
            Log.Information("No pluginfolder found. Creating one..");
            Directory.CreateDirectory("plugins");
            return;
        }

        string[] pluginFolders = Directory.GetDirectories("plugins");
        List<PluginLoader> temp = new List<PluginLoader>();
        foreach (string folder in pluginFolders)
        {
            PluginLoader? tempPlugin = LoadPlugin(folder, true);
            if (tempPlugin == null) continue;
            temp.Add(tempPlugin);
            Log.Information("Plugin from folder: {0} loaded.", folder.Replace(Path.DirectorySeparatorChar + "plugins", ""));
        }

        Log.Information("Starting plugins..");
        foreach (PluginLoader pluginLoader in temp)
        {
            IPlugin plugin = StartPlugin(pluginLoader);
            Log.Information("Plugin: {0} ({1}) by [{2}] started.", plugin.Name, plugin.Version, plugin.Author);
        }
    }
}