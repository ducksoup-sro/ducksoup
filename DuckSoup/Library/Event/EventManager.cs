using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Event;
using API.ServiceFactory;
using McMaster.NETCore.Plugins;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Serilog;

namespace DuckSoup.Library.Event;

public class EventManager : IEventManager
{
    private const string EventConfigFileName = "event.json";
    private const string EventsDirectory = "events";
    private readonly StdSchedulerFactory _schedulerFactory;
    private readonly Dictionary<string, string> _folderByEventName = new(StringComparer.OrdinalIgnoreCase);

    public EventManager()
    {
        ServiceFactory.Register<IEventManager>(typeof(IEventManager), this);
        _schedulerFactory = new StdSchedulerFactory();

        IScheduler scheduler = _schedulerFactory.GetScheduler().Result;
        scheduler.Start();

        Loaders = new Dictionary<PluginLoader, IEvent>();
        Triggers = new Dictionary<string, TriggerKey>();
        Setup();
    }

    private Dictionary<string, TriggerKey> Triggers { get; }

    public Dictionary<PluginLoader, IEvent> Loaders { get; private set; }

    public bool IsLoaded(string name)
    {
        foreach ((PluginLoader _, IEvent value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
                return true;
        }

        return false;
    }

    public PluginLoader? LoadEvent(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return null;
        var fullPath = Path.IsPathRooted(path) ? path : Path.Combine(Directory.GetCurrentDirectory(), path);
        if (Directory.Exists(fullPath))
            return LoadEventFromFolder(fullPath);
        return PluginLoader.CreateFromAssemblyFile(fullPath,
            config =>
            {
                config.IsUnloadable = true;
                config.LoadInMemory = true;
                config.PreferSharedTypes = true;
            });
    }

    private PluginLoader? LoadEventFromFolder(string folderPath)
    {
        var configFile = Path.Combine(folderPath, EventConfigFileName);
        if (!File.Exists(configFile))
        {
            Log.Warning("No {0} found in: {1}", EventConfigFileName, folderPath);
            return null;
        }

        var configJson = File.ReadAllText(configFile);
        var config = JsonConvert.DeserializeObject<EventConfig>(configJson);
        if (config == null || string.IsNullOrWhiteSpace(config.MainLibrary))
        {
            Log.Warning("{0} was faulty in: {1}", EventConfigFileName, folderPath);
            return null;
        }

        var absoluteDllPath = Path.Combine(folderPath, config.MainLibrary);
        if (!File.Exists(absoluteDllPath))
        {
            Log.Warning("Event DLL not found: {0}", absoluteDllPath);
            return null;
        }

        return PluginLoader.CreateFromAssemblyFile(absoluteDllPath,
            config =>
            {
                config.IsUnloadable = true;
                config.LoadInMemory = true;
                config.PreferSharedTypes = true;
            });
    }

    public IEvent StartEvent(PluginLoader pluginLoader)
    {
        return StartEvent(pluginLoader, null);
    }

    public IEvent StartEvent(PluginLoader pluginLoader, string? folderName)
    {
        using API.Database.Context.DuckSoup context = new API.Database.Context.DuckSoup();
        List<API.Database.DuckSoup.Event> eventTable = context.Events.ToList();

        IEvent eEvent = null;
        foreach (Type pluginType in pluginLoader
                     .LoadDefaultAssembly()
                     .GetTypes()
                     .Where(t => typeof(IEvent).IsAssignableFrom(t) && !t.IsAbstract))
        {
            eEvent = (IEvent)Activator.CreateInstance(pluginType)!;
            eEvent.OnEnable();
            List<API.Database.DuckSoup.Event> tableList = eventTable.Where(s => s.Eventname.Equals(eEvent.Name)).ToList();
            if (tableList.Count == 0)
            {
                Log.Information(
                    "Event {0} ({1}) by [{2}] has no cronjob entry. Please add one and unload, load again. Otherwise it won't be triggered",
                    eEvent.Name, eEvent.Version, eEvent.Author);
            }
            else
            {
                Log.Information("Event {0} ({1}) by [{2}] has {3} cronjob entry/s.", eEvent.Name,
                    eEvent.Version, eEvent.Author, tableList.Count);

                for (int i = 0; i < tableList.Count; i++)
                {
                    StartScheduler(eEvent, i, tableList[i].Crontime);
                }
            }

            if (!string.IsNullOrEmpty(folderName))
                _folderByEventName[eEvent.Name] = folderName;

            Loaders.Add(pluginLoader, eEvent);
        }

        return eEvent;
    }

    /// <summary>Returns folder names (subdirs of events/ with event.json) that are not currently loaded. Event name comes from IEvent.Name when loaded.</summary>
    public IReadOnlyList<string> GetAvailableEventFolderNames()
    {
        var loadedFolderNames = new HashSet<string>(_folderByEventName.Values, StringComparer.OrdinalIgnoreCase);
        var eventsPath = Path.Combine(Directory.GetCurrentDirectory(), EventsDirectory);
        if (!Directory.Exists(eventsPath)) return Array.Empty<string>();
        var list = new List<string>();
        foreach (var dir in Directory.GetDirectories(eventsPath))
        {
            var configFile = Path.Combine(dir, EventConfigFileName);
            if (!File.Exists(configFile)) continue;
            var folderName = Path.GetFileName(dir);
            if (string.IsNullOrEmpty(folderName)) continue;
            if (loadedFolderNames.Contains(folderName)) continue;
            list.Add(folderName);
        }
        return list;
    }

    public bool UnloadEvent(string name)
    {
        Dictionary<PluginLoader, IEvent> removeEvents = new Dictionary<PluginLoader, IEvent>();

        foreach ((PluginLoader key, IEvent value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
                removeEvents.Add(key, value);
        }

        foreach ((PluginLoader _, IEvent value) in removeEvents)
        {
            _folderByEventName.Remove(value.Name);
            return UnloadEvent(value);
        }

        return false;
    }

    public bool UnloadEvent(IEvent eEvent)
    {
        List<string> triggerList = new List<string>();
        foreach ((PluginLoader key, IEvent value) in Loaders)
        {
            if (!value.Name.ToLower().Equals(eEvent.Name.ToLower())) continue;

            triggerList.AddRange(from keyValuePair in Triggers
                where keyValuePair.Key.StartsWith($"{eEvent.Name}Job")
                select keyValuePair.Key);
            foreach (string s in triggerList)
            {
                TriggerKey? trigger = Triggers[s];
                if (trigger == null) continue;
                _schedulerFactory.GetScheduler().Result.UnscheduleJob(trigger);
                Triggers.Remove(s);
            }

            _folderByEventName.Remove(value.Name);
            eEvent.Dispose();
            key.Dispose();
            return UnloadEvent(key);
        }

        return false;
    }

    public bool UnloadEvent(PluginLoader pluginLoader)
    {
        pluginLoader.Dispose();
        Loaders.Remove(pluginLoader);
        bool check = !Loaders.ContainsKey(pluginLoader);
        return check;
    }

    /// <summary>Searches for an event by name: finds subfolder with event.json whose folder name matches (convention: folder name = IEvent.Name). Returns folder path or null.</summary>
    public string? SearchEvent(string directory, string eventName)
    {
        if (string.IsNullOrWhiteSpace(directory) || string.IsNullOrWhiteSpace(eventName)) return null;
        var eventsPath = Path.IsPathRooted(directory) ? directory : Path.Combine(Directory.GetCurrentDirectory(), directory);
        if (!Directory.Exists(eventsPath)) return null;

        var searchName = eventName.Trim();
        foreach (var dir in Directory.GetDirectories(eventsPath))
        {
            var configFile = Path.Combine(dir, EventConfigFileName);
            if (!File.Exists(configFile)) continue;
            var folderName = Path.GetFileName(dir);
            if (string.IsNullOrEmpty(folderName)) continue;
            if (!folderName.Equals(searchName, StringComparison.OrdinalIgnoreCase)) continue;
            return dir;
        }

        return null;
    }

    public bool ReloadEvent(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;
        var eventsPath = Path.Combine(Directory.GetCurrentDirectory(), EventsDirectory);
        var folderPath = SearchEvent(eventsPath, name);
        if (string.IsNullOrEmpty(folderPath)) return false;
        UnloadEvent(name);
        var loader = LoadEventFromFolder(folderPath);
        if (loader == null) return false;
        var folderName = Path.GetFileName(folderPath);
        StartEvent(loader, folderName);
        return true;
    }

    public void Dispose()
    {
        foreach ((PluginLoader _, IEvent value) in Loaders)
        {
            value.Dispose();
        }

        Loaders = null;
    }

    private async void StartScheduler(IEvent eEvent, int index, string crontime)
    {
        if (string.IsNullOrWhiteSpace(crontime))
        {
            Log.Warning("Event {0} cron index {1}: empty expression, skipping.", eEvent.Name, index);
            return;
        }

        try
        {
            CronExpression.ValidateExpression(crontime);
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Event {0} cron index {1}: invalid expression \"{2}\", skipping.", eEvent.Name, index, crontime);
            return;
        }

        IScheduler scheduler = await _schedulerFactory.GetScheduler();
        IJobDetail job = JobBuilder.Create<EventJob>()
            .WithIdentity($"{eEvent.Name}Job{index}", "events")
            .Build();
        job.JobDataMap["event"] = eEvent;

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity($"{eEvent.Name}Trigger{index}", "events")
            .WithCronSchedule(crontime)
            .StartNow()
            .Build();

        Triggers.Add($"{eEvent.Name}Job{index}", trigger.Key);

        await scheduler.ScheduleJob(job, trigger);
    }

    private void Setup()
    {
        Log.Information("Loading events..");
        var eventsPath = Path.Combine(Directory.GetCurrentDirectory(), EventsDirectory);
        if (!Directory.Exists(eventsPath))
        {
            Log.Information("No event folder found. Creating one..");
            Directory.CreateDirectory(eventsPath);
            return;
        }

        var temp = new List<(PluginLoader? Loader, string FolderName)>();
        foreach (var dir in Directory.GetDirectories(eventsPath))
        {
            var configFile = Path.Combine(dir, EventConfigFileName);
            if (!File.Exists(configFile)) continue;
            var configJson = File.ReadAllText(configFile);
            var config = JsonConvert.DeserializeObject<EventConfig>(configJson);
            if (config == null || !config.AutoStart)
            {
                Log.Information("Event folder {0} has AutoStart=false or invalid event.json, skipping.", Path.GetFileName(dir));
                continue;
            }
            var loader = LoadEventFromFolder(dir);
            if (loader == null) continue;
            var folderName = Path.GetFileName(dir) ?? "";
            temp.Add((loader, folderName));
            Log.Information("Event from folder: {0} loaded.", folderName);
        }

        Log.Information("Starting events..");
        foreach (var (loader, folderName) in temp)
        {
            if (loader == null) continue;
            var eEvent = StartEvent(loader, folderName);
            if (eEvent == null)
            {
                Log.Warning("Event DLL did not contain an IEvent implementation. Skipping.");
                loader.Dispose();
                continue;
            }
            Log.Information("Event: {0} ({1}) by [{2}] started.", eEvent.Name, eEvent.Version, eEvent.Author);
        }
    }
}