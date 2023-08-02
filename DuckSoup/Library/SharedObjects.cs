using System.Collections.Generic;
using API;
using API.Database;
using API.ServiceFactory;
using PacketLibrary.Handler;

namespace DuckSoup.Library;

public class SharedObjects : ISharedObjects
{
    public static DebugLevel DebugLevel;
    public static string ServerName;

    public SharedObjects()
    {
        ServiceFactory.Register<ISharedObjects>(typeof(ISharedObjects), this);

        ServerName = DatabaseHelper.GetSettingOrDefault("Name", "Filter");
        DebugLevel =
            (DebugLevel)int.Parse(
                DatabaseHelper.GetSettingOrDefault("DebugLevel", ((byte)DebugLevel.Info).ToString()));

        AgentSessions = new HashSet<ISession>();
        DownloadSessions = new HashSet<ISession>();
        GatewaySessions = new HashSet<ISession>();
    }

    public HashSet<ISession> AgentSessions { get; private set; }
    public HashSet<ISession> DownloadSessions { get; private set; }
    public HashSet<ISession> GatewaySessions { get; private set; }

    public void Dispose()
    {
        AgentSessions = null;
        DownloadSessions = null;
        GatewaySessions = null;
    }
}