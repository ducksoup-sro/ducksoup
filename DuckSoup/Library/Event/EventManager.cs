using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Event;
using API.ServiceFactory;
using McMaster.NETCore.Plugins;
using Quartz;
using Quartz.Impl;

namespace DuckSoup.Library.Event;

public class EventManager : IEventManager
{
    private readonly StdSchedulerFactory _schedulerFactory;

    public Dictionary<PluginLoader, IEvent> Loaders { get; private set; }
    private Dictionary<string, TriggerKey> Triggers { get; set; }

    public EventManager()
    {
        ServiceFactory.Register<IEventManager>(typeof(IEventManager), this);
        _schedulerFactory = new StdSchedulerFactory();

        var scheduler = _schedulerFactory.GetScheduler().Result;
        scheduler.Start();

        Loaders = new Dictionary<PluginLoader, IEvent>();
        Triggers = new Dictionary<string, TriggerKey>();
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

    public PluginLoader LoadEvent(string file)
    {
        return PluginLoader.CreateFromAssemblyFile(Directory.GetCurrentDirectory() + "\\" + file,
            configure: config =>
            {
                config.IsUnloadable = true;
                config.LoadInMemory = true;
                config.PreferSharedTypes = true;
            });
    }

    public IEvent StartEvent(PluginLoader pluginLoader)
    {
        using var context = new API.Database.DuckSoup.DuckSoup();
        var eventTable = context.Event.ToList();

        IEvent eEvent = null;
        foreach (var pluginType in pluginLoader
                     .LoadDefaultAssembly()
                     .GetTypes()
                     .Where(t => typeof(IEvent).IsAssignableFrom(t) && !t.IsAbstract))
        {
            // This assumes the implementation of IPlugin has a parameterless constructor
            eEvent = (IEvent) Activator.CreateInstance(pluginType)!;
            eEvent.OnEnable();
            var tableList = eventTable.Where(s => s.Eventname.Equals(eEvent.Name)).ToList();
            if (tableList.Count == 0)
            {
                Global.Logger.InfoFormat(
                    "Event {0} ({1}) by [{2}] has no cronjob entry. Please add one and unload, load again. Otherwise it won't be triggered",
                    eEvent.Name, eEvent.Version, eEvent.Author);
            }
            else
            {
                Global.Logger.InfoFormat("Event {0} ({1}) by [{2}] has {3} cronjob entry/s.", eEvent.Name,
                    eEvent.Version, eEvent.Author, tableList.Count);

                for (var i = 0; i < tableList.Count; i++)
                {
                    StartScheduler(eEvent, i, tableList[i].Crontime);
                }
            }

            Loaders.Add(pluginLoader, eEvent);
        }

        return eEvent;
    }

    private async void StartScheduler(IEvent eEvent, int index, string crontime)
    {
        var scheduler = await _schedulerFactory.GetScheduler();
        var job = JobBuilder.Create<EventJob>()
            .WithIdentity($"{eEvent.Name}Job{index}", "events")
            .Build();
        job.JobDataMap["event"] = eEvent;

        var trigger = TriggerBuilder.Create()
            .WithIdentity($"{eEvent.Name}Trigger", "events")
            .WithCronSchedule(crontime)
            .StartNow()
            .Build();

        Triggers.Add($"{eEvent.Name}Job{index}", trigger.Key);

        await scheduler.ScheduleJob(job, trigger);
    }

    public bool UnloadEvent(string name)
    {
        var removeEvents = new Dictionary<PluginLoader, IEvent>();

        foreach (var (key, value) in Loaders)
        {
            if (value.Name.ToLower().Equals(name.ToLower()))
            {
                removeEvents.Add(key, value);
            }
        }

        foreach (var (_, value) in removeEvents)
        {
            return UnloadEvent(value);
        }

        return false;
    }

    public bool UnloadEvent(IEvent eEvent)
    {
        var triggerList = new List<string>();
        foreach (var (key, value) in Loaders)
        {
            if (!value.Name.ToLower().Equals(eEvent.Name.ToLower()))
            {
                continue;
            }

            triggerList.AddRange(from keyValuePair in Triggers
                where keyValuePair.Key.StartsWith($"{eEvent.Name}Job")
                select keyValuePair.Key);
            foreach (var s in triggerList)
            {
                var trigger = Triggers[s];
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
        var check = !Loaders.ContainsKey(pluginLoader);
        return check;
    }

    public List<string> GetFilesInDirectory(string directory)
    {
        return !Directory.Exists(directory)
            ? null
            : Directory.GetFiles(directory).Where(file => file.EndsWith(".dll")).ToList();
    }

    public string SearchEvent(string directory, string eventName)
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

            var replace = file.ToLower().Replace("event.", "").Replace(".dll", "").Replace(directory, "")
                .Replace("\\", "");
            var searchName = eventName.Replace("event.", "").Replace(".dll", "");

            if (replace.ToLower().Equals(searchName.ToLower()))
            {
                return file;
            }
        }

        return null;
    }

    private void Setup()
    {
        Global.Logger.InfoFormat("Loading events..");
        var pluginFiles = GetFilesInDirectory("events");
        if (pluginFiles == null)
        {
            Global.Logger.InfoFormat("No eventfolder found. Creating one..");
            Directory.CreateDirectory("events");
            return;
        }

        var temp = new List<PluginLoader>();
        foreach (var file in pluginFiles)
        {
            temp.Add(LoadEvent(file));
            Global.Logger.InfoFormat("Plugin: {0} loaded.", file.Replace("\\events", ""));
        }

        Global.Logger.InfoFormat("Starting events..");
        foreach (var pluginLoader in temp)
        {
            var eEvent = StartEvent(pluginLoader);
            Global.Logger.InfoFormat("Event: {0} ({1}) by [{2}] started.", eEvent.Name, eEvent.Version, eEvent.Author);
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