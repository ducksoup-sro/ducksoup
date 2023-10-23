#region

#endregion

namespace API;

public static class Global
{
    public static double CurrentMillis()
    {
        return (TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) -
                new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }
}

public enum ServerType
{
    None,
    DownloadServer,
    GatewayServer,
    AgentServer
}

public enum DebugLevel
{
    Nothing, // do not use!
    Fatal, // failure but the server can't keep going
    Critical, // failure but the server can keep going
    Warning, // exploits, protection stuff
    Info, // everything that regards the server
    Connections, // Connection stuff (incoming / outgoing, destroying and so on)
    Debug, // debugging of Packets
    Everything
}