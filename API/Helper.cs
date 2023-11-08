using API.Session;
using PacketLibrary.Handler;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace API;

public static class Helper
{
    public static Task<ISession?> GetSessionByGuid(Guid guid)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session => session.Guid.Equals(guid)));
    }

    public static Task<ISession?> GetSessionByCharName(string charName)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return string.Equals(charInfo.CharName, charName, StringComparison.OrdinalIgnoreCase);
        }));
    }

    public static Task<ISession?> GetSessionByAccountJid(int accountJid)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(sharedObjects.AgentSessions.FirstOrDefault(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return charInfo.Jid == accountJid;
        }));
    }

    public static Task<List<ISession>> GetSessionsInRegion(int regionId)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return charInfo.GetCalcPosition.Region.Id == regionId;
        }).ToList();
        return Task.FromResult(result);
    }

    public static Task<List<ISession>> GetSessionsInSector(int sectorX, int sectorY)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        var result = sharedObjects.AgentSessions.Where(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? targetCharInfo, null);
            if (targetCharInfo == null) return false;
            var targetSectorX = targetCharInfo.GetCalcPosition.Region.X;
            var targetSectorY = targetCharInfo.GetCalcPosition.Region.Y;
            return targetSectorX == sectorX && targetSectorY == sectorY;
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
                targetSession.GetData(Data.CharacterGameReady, out var characterGameReady, false);

                if (characterGameReady != clientIsReady) continue;

                targetSession.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
                if (charInfo == null) return;
                if (charInfo.GetCalcPosition.Region.Id == regionId) targetSession.SendToClient(packet);
            }
        });
    }

    public static async Task BroadcastPacketNearSession(ISession session, Packet packet, int distanceX = 1,
        int distanceY = 1, bool clientIsReady = true)
    {
        var sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        if (charInfo == null) return;

        var sectorX = charInfo.GetCalcPosition.Region.X;
        var sectorY = charInfo.GetCalcPosition.Region.Y;
        await Task.Run(() =>
        {
            foreach (var targetSession in sharedObjects.AgentSessions)
            {
                targetSession.GetData(Data.CharacterGameReady, out var characterGameReady, false);
                if (characterGameReady != clientIsReady) continue;

                targetSession.GetData(Data.CharInfo, out ICharInfo? targetCharInfo, null);
                if (targetCharInfo == null) continue;

                var targetSectorX = targetCharInfo.GetCalcPosition.Region.X;
                var targetSectorY = targetCharInfo.GetCalcPosition.Region.Y;
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
                        session.GetData(Data.CharacterGameReady, out var characterGameReady, false);
                        if (characterGameReady != clientIsReady) continue;
                        session.SendToClient(packet);
                    }

                    break;
                default:
                    Log.Error("Helper - BroadcastPacket - {0}, {1}", nameof(serverType), serverType);
                    break;
            }
        });
    }
}