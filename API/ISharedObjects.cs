using ConcurrentCollections;
using PacketLibrary.Handler;

namespace API;

public interface ISharedObjects : IDisposable
{
    ConcurrentHashSet<ISession> DownloadSessions { get; }
    ConcurrentHashSet<ISession> GatewaySessions { get; }
    ConcurrentHashSet<ISession> AgentSessions { get; }

    void AddOrUpdateTokenRoute(uint token, string host, ushort port);
    bool TryTakeTokenRoute(uint token, out SinglePortTokenRoute route);
    bool TryGetLatestTokenRoute(out SinglePortTokenRoute? route);
}