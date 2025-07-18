using ConcurrentCollections;
using PacketLibrary.Handler;

namespace API;

public interface ISharedObjects : IDisposable
{
    ConcurrentHashSet<ISession> DownloadSessions { get; }
    ConcurrentHashSet<ISession> GatewaySessions { get; }
    ConcurrentHashSet<ISession> AgentSessions { get; }
}