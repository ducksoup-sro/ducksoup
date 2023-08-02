using PacketLibrary.Handler;

namespace API;

public interface ISharedObjects : IDisposable
{
    HashSet<ISession> DownloadSessions { get; }
    HashSet<ISession> GatewaySessions { get; }
    HashSet<ISession> AgentSessions { get; }
}