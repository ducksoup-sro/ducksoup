using API.Session;
using PacketLibrary.Handler;
using SilkroadSecurityAPI.Message;

namespace API;

public static class Helper
{
    public static long GetCurrentTimeMillis()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    public static long GetCurrentTimeSeconds()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public static Task<ISession?> GetSessionByGuid(Guid guid)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session => session.Guid.Equals(guid)));
    }

    public static Task<ISession?> GetSessionByCharname(string charname)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session =>
        {
            session.GetData(SessionConst.CHARNAME, out string? sessionCharName);
            return string.Equals(sessionCharName, charname, StringComparison.OrdinalIgnoreCase);
        }));
    }

    public static Task<ISession?> GetSessionByAccountJID(int accountJID)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session =>
        {
            session.GetData(SessionConst.JID, out int jid);
            return jid == accountJID;
        }));
    }

    public static Task<List<ISession>> GetSessionsInRegion(int regionId)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session =>
        {
            session.GetData(SessionConst.REGION_ID, out int sessionRegionId);
            return sessionRegionId == regionId;
        }).ToList();
        return Task.FromResult(result);
    }

    public static Task<List<ISession>> GetSessionsInSectorXY(int x, int y)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session =>
        {
            session.GetData<int>(SessionConst.SECTOR_X, out var sectorX);
            session.GetData<int>(SessionConst.SECTOR_Y, out var sectorY);
            return sectorX == x && sectorY == y;
        }).ToList();
        return Task.FromResult(result);
    }

    public static async Task BroadcastPacketToRegion(int regionId, Packet packet, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            foreach (var targetSession in sharedObjects.AgentSessions)
            {
                targetSession.GetData<bool>(SessionConst.CHARACTER_GAME_READY, out var characterGameReady);

                if (clientIsReady && !characterGameReady) continue;

                targetSession.GetData<int>(SessionConst.REGION_ID, out var targetRegionId);

                if (targetRegionId == regionId) targetSession.SendToClient(packet);
            }
        });
    }

    public static async Task BroadcastPacketNearSession(ISession session, Packet packet, int distanceX = 1,
        int distanceY = 1, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            foreach (var targetSession in sharedObjects.AgentSessions)
            {
                targetSession.GetData<bool>(SessionConst.CHARACTER_GAME_READY, out var characterGameReady);

                if (clientIsReady && !characterGameReady) continue;

                session.GetData<int>(SessionConst.SECTOR_X, out var sectorX);
                session.GetData<int>(SessionConst.SECTOR_Y, out var sectorY);
                targetSession.GetData<int>(SessionConst.SECTOR_X, out var targetSectorX);
                targetSession.GetData<int>(SessionConst.SECTOR_Y, out var targetSectorY);

                if ((targetSectorX + 1 == sectorX ||
                     targetSectorX - 1 == sectorX ||
                     targetSectorX == sectorX) &&
                    (targetSectorY + 1 == sectorY ||
                     targetSectorY - 1 == sectorY ||
                     targetSectorY == sectorY)
                   )
                    targetSession.SendToClient(packet);
            }
        });
    }

    public static async Task BroadcastPacket(Packet packet, ServerType serverType = ServerType.AgentServer,
        bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            switch (serverType)
            {
                case ServerType.None:
                    break;
                case ServerType.DownloadServer:
                    foreach (var session in sharedObjects.DownloadSessions) session.SendToClient(packet);
                    break;
                case ServerType.GatewayServer:
                    foreach (var session in sharedObjects.GatewaySessions) session.SendToClient(packet);
                    break;
                case ServerType.AgentServer:
                    foreach (var session in sharedObjects.AgentSessions)
                    {
                        session.GetData<bool>(SessionConst.CHARACTER_GAME_READY, out var characterGameReady);

                        if (!characterGameReady) return;
                        session.SendToClient(packet);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(serverType), serverType, null);
            }
        });
    }
}