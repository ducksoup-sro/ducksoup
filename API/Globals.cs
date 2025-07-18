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