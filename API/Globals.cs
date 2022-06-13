#region

using System.Reflection;
using log4net;

#endregion

namespace API
{
    public static class Global
    {
        public static readonly ILog Logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static double CurrentMillis()
        {
            return (TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) -
                    new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }

    public enum PacketResultType
    {
        Disconnect, // if used in a multi handler setup it will disconnect the player immediately 
        Override, // if used in a multi handler setup the next handler will use the overridden packet! 
        Block, // if used in a multi handler setup it will block ALL FURTHER PACKETHANDLERS
        Nothing // if used in a multi handler setup it will do nothing and the following handler will use just use the packet again
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
}