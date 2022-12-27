using API.Session;
using SilkroadSecurityAPI;

namespace API;

public static class Helper
{
    public static long GetCurrentTimeMillis()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public static Task<ISession?> GetSessionByGuid(Guid guid)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session => session.ClientGuid.Equals(guid)));
    }
    
    public static Task<ISession?> GetSessionByCharname(string charname)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session => string.Equals(session.SessionData.Charname, charname, StringComparison.OrdinalIgnoreCase)));
    }
    
    public static Task<ISession?> GetSessionByAccountJID(int accountJID)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session => session.SessionData.JID == accountJID));
    }

    public static Task<List<ISession>> GetSessionsInRegion(int regionId)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session => session.SessionData.LatestRegionId == regionId).ToList();
        return Task.FromResult(result);
    }
    
    public static Task<List<ISession>> GetSessionsInSectorXY(int x, int y)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session => session.SessionData.SectorX == x && session.SessionData.SectorY == y).ToList();
        return Task.FromResult(result);
    }

    public static async Task BroadcastPacketToRegion(int regionId, Packet packet, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            foreach (var targetSession in sharedObjects.AgentSessions)
            {
                if (clientIsReady && !targetSession.CharacterGameReady)
                {
                    continue;
                }

                if (targetSession.SessionData.LatestRegionId == regionId)
                {
                    targetSession.SendToClient(packet);
                }
            }
        });
    }
    
    public static async Task BroadcastPacketNearSession(ISession session, Packet packet, int distanceX = 1, int distanceY = 1, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            foreach (var targetSession in sharedObjects.AgentSessions)
            {
                if (clientIsReady && !targetSession.CharacterGameReady)
                {
                    continue;
                }

                if ((targetSession.SessionData.SectorX + 1 == session.SessionData.SectorX ||
                     targetSession.SessionData.SectorX - 1 == session.SessionData.SectorX ||
                     targetSession.SessionData.SectorX == session.SessionData.SectorX) &&
                    (targetSession.SessionData.SectorY + 1 == session.SessionData.SectorY ||
                     targetSession.SessionData.SectorY - 1 == session.SessionData.SectorY ||
                     targetSession.SessionData.SectorY == session.SessionData.SectorY)
                   )
                {
                    targetSession.SendToClient(packet);
                }
            }
        });
    }
    
    public static async Task BroadcastPacket(Packet packet, ServerType serverType = ServerType.AgentServer, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            switch (serverType)
            {
                case ServerType.None:
                    break;
                case ServerType.DownloadServer:
                    foreach (var session in sharedObjects.DownloadSessions)
                    {
                        session.SendToClient(packet);
                    }
                    break;
                case ServerType.GatewayServer:
                    foreach (var session in sharedObjects.GatewaySessions)
                    {
                        session.SendToClient(packet);
                    }
                    break;
                case ServerType.AgentServer:
                    foreach (var session in sharedObjects.AgentSessions)
                    {
                        if (!session.CharacterGameReady)
                        {
                            return;
                        }
                        session.SendToClient(packet);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serverType), serverType, null);
            }
        });
    }
}