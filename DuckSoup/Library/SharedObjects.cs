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
    public static string ServerName;

    public SharedObjects()
    {
        ServiceFactory.Register<ISharedObjects>(typeof(ISharedObjects), this);

        ServerName = DatabaseHelper.GetSettingOrDefault("Name", "Filter");
        DebugLevel =
            (LogEventLevel)int.Parse(
                DatabaseHelper.GetSettingOrDefault("DebugLevel", ((byte)LogEventLevel.Information).ToString()));

        Helper.LoggingLevelSwitch.MinimumLevel = LogEventLevel.Verbose;
        Log.Information("Log is on {0} ({1}) its recommend to set it to 2 (Information) in the database", (byte)DebugLevel, DebugLevel);
        Helper.LoggingLevelSwitch.MinimumLevel = DebugLevel;

        AgentSessions = new ConcurrentHashSet<ISession>();
        DownloadSessions = new ConcurrentHashSet<ISession>();
        GatewaySessions = new ConcurrentHashSet<ISession>();
    }

    public ConcurrentHashSet<ISession> AgentSessions { get; private set; }
    public ConcurrentHashSet<ISession> DownloadSessions { get; private set; }
    public ConcurrentHashSet<ISession> GatewaySessions { get; private set; }

    public void Dispose()
    {
        AgentSessions = null;
        DownloadSessions = null;
        GatewaySessions = null;
    }
}