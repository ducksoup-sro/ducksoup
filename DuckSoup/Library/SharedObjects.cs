using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using API;
using API.Database;
using API.ServiceFactory;
using ConcurrentCollections;
using PacketLibrary.Handler;
using Serilog;
using Serilog.Events;

namespace DuckSoup.Library;

public class SharedObjects : ISharedObjects
{
    public static LogEventLevel DebugLevel;
    private static readonly TimeSpan TokenRouteTtl = TimeSpan.FromMinutes(2);
    private readonly object _latestTokenRouteLock = new();
    private SinglePortTokenRoute? _latestTokenRoute;

    public SharedObjects()
    {
        ServiceFactory.Register<ISharedObjects>(typeof(ISharedObjects), this);

        DebugLevel =
            (LogEventLevel)int.Parse(
                DatabaseHelper.GetSettingOrDefault("DebugLevel", ((byte)LogEventLevel.Information).ToString()));

        Helper.LoggingLevelSwitch.MinimumLevel = LogEventLevel.Verbose;
        Log.Information("Log is on {0} ({1}) its recommend to set it to 2 (Information) in the database", (byte)DebugLevel, DebugLevel);
        Helper.LoggingLevelSwitch.MinimumLevel = DebugLevel;

        AgentSessions = new ConcurrentHashSet<ISession>();
        DownloadSessions = new ConcurrentHashSet<ISession>();
        GatewaySessions = new ConcurrentHashSet<ISession>();
        TokenRoutes = new ConcurrentDictionary<uint, SinglePortTokenRoute>();
    }

    public ConcurrentHashSet<ISession> AgentSessions { get; private set; }
    public ConcurrentHashSet<ISession> DownloadSessions { get; private set; }
    public ConcurrentHashSet<ISession> GatewaySessions { get; private set; }
    private ConcurrentDictionary<uint, SinglePortTokenRoute> TokenRoutes { get; set; }

    public void AddOrUpdateTokenRoute(uint token, string host, ushort port)
    {
        CleanupTokenRoutes();
        SinglePortTokenRoute route = new SinglePortTokenRoute(host, port, DateTime.UtcNow);
        TokenRoutes[token] = route;
        lock (_latestTokenRouteLock)
        {
            _latestTokenRoute = route;
        }
    }

    public bool TryTakeTokenRoute(uint token, out SinglePortTokenRoute route)
    {
        CleanupTokenRoutes();
        return TokenRoutes.TryRemove(token, out route);
    }

    public bool TryGetLatestTokenRoute(out SinglePortTokenRoute? route)
    {
        CleanupTokenRoutes();
        lock (_latestTokenRouteLock)
        {
            route = _latestTokenRoute;
        }

        return route != null;
    }

    private void CleanupTokenRoutes()
    {
        DateTime threshold = DateTime.UtcNow.Subtract(TokenRouteTtl);
        foreach (KeyValuePair<uint, SinglePortTokenRoute> entry in TokenRoutes)
        {
            if (entry.Value.CreatedAtUtc >= threshold)
            {
                continue;
            }

            TokenRoutes.TryRemove(entry.Key, out _);
        }

        lock (_latestTokenRouteLock)
        {
            if (_latestTokenRoute != null && _latestTokenRoute.CreatedAtUtc < threshold)
            {
                _latestTokenRoute = null;
            }
        }
    }

    public void Dispose()
    {
        AgentSessions = null;
        DownloadSessions = null;
        GatewaySessions = null;
        TokenRoutes = null;
    }
}