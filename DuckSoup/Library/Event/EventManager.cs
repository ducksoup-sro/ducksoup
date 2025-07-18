using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Event;
using API.ServiceFactory;
using McMaster.NETCore.Plugins;
using Quartz;
using Quartz.Impl;
using Serilog;

namespace DuckSoup.Library.Event;

public class EventManager : IEventManager
{
    private readonly StdSchedulerFactory _schedulerFactory;

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

    public PluginLoader LoadEvent(string file)
    {
        return PluginLoader.CreateFromAssemblyFile(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + file,
            config =>
            {
                config.IsUnloadable = true;
                config.LoadInMemory = true;
                config.PreferSharedTypes = true;
            });
    }

    public IEvent StartEvent(PluginLoader pluginLoader)
    {
        using API.Database.Context.DuckSoup context = new API.Database.Context.DuckSoup();
        List<API.Database.DuckSoup.Event> eventTable = context.Events.ToList();

        IEvent eEvent = null;
        foreach (Type pluginType in pluginLoader
                     .LoadDefaultAssembly()
                     .GetTypes()
                     .Where(t => typeof(IEvent).IsAssignableFrom(t) && !t.IsAbstract))
        {
            // This assumes the implementation of IPlugin has a parameterless constructor
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

            Loaders.Add(pluginLoader, eEvent);
        }

        return eEvent;
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

    public string SearchEvent(string directory, string eventName)
    {
        if (!Directory.Exists(directory)) return null;

        foreach (string file in Directory.GetFiles(directory))
        {
            if (!file.EndsWith(".dll")) continue;

            string replace = file.ToLower().Replace("event.", "").Replace(".dll", "").Replace(directory, "")
                .Replace("\\", "");
            string searchName = eventName.Replace("event.", "").Replace(".dll", "");

            if (replace.ToLower().Equals(searchName.ToLower())) return file;
        }

        return null;
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
        IScheduler scheduler = await _schedulerFactory.GetScheduler();
        IJobDetail job = JobBuilder.Create<EventJob>()
            .WithIdentity($"{eEvent.Name}Job{index}", "events")
            .Build();
        job.JobDataMap["event"] = eEvent;

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity($"{eEvent.Name}Trigger", "events")
            .WithCronSchedule(crontime)
            .StartNow()
            .Build();

        Triggers.Add($"{eEvent.Name}Job{index}", trigger.Key);

        await scheduler.ScheduleJob(job, trigger);
    }

    private void Setup()
    {
        Log.Information("Loading events..");
        if (!Directory.Exists("events"))
        {
            Log.Information("No eventfolder found. Creating one..");
            Directory.CreateDirectory("events");
            return;
        }

        List<string> pluginFiles = Directory.GetFiles("events").Where(file => file.EndsWith(".dll")).ToList();

        List<PluginLoader> temp = new List<PluginLoader>();
        foreach (string file in pluginFiles)
        {
            temp.Add(LoadEvent(file));
            Log.Information("Plugin: {0} loaded.", file.Replace("\\events", ""));
        }

        Log.Information("Starting events..");
        foreach (PluginLoader pluginLoader in temp)
        {
            IEvent eEvent = StartEvent(pluginLoader);
            Log.Information("Event: {0} ({1}) by [{2}] started.", eEvent.Name, eEvent.Version, eEvent.Author);
        }
    }
}