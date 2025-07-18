using API.Session;
using ConcurrentCollections;
using PacketLibrary.Handler;
using Serilog;
using Serilog.Core;
using SilkroadSecurityAPI.Message;

namespace API;

public static class Helper
{
    public static LoggingLevelSwitch LoggingLevelSwitch { get; } = new LoggingLevelSwitch();

    public static Task<ISession?> GetSessionByUniqueId(uint uniqueId)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(new HashSet<ISession>(sharedObjects.AgentSessions).FirstOrDefault(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return charInfo.UniqueCharId == uniqueId;
        }));
    }

    public static Task<ISession?> GetSessionByGuid(Guid guid)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(new HashSet<ISession>(sharedObjects.AgentSessions).FirstOrDefault(session => session.Guid.Equals(guid)));
    }

    public static Task<ISession?> GetSessionByCharName(string charName)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(new HashSet<ISession>(sharedObjects.AgentSessions).FirstOrDefault(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return string.Equals(charInfo.CharName, charName, StringComparison.OrdinalIgnoreCase);
        }));
    }

    public static Task<ISession?> GetSessionByAccountJid(int accountJid)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        return Task.FromResult(new HashSet<ISession>(sharedObjects.AgentSessions).FirstOrDefault(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return charInfo.Jid == accountJid;
        }));
    }

    public static Task<List<ISession>> GetSessionsInRegion(int regionId)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        List<ISession> result = new HashSet<ISession>(sharedObjects.AgentSessions).Where(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
            if (charInfo == null) return false;
            return charInfo.GetCalcPosition.Region.Id == regionId;
        }).ToList();
        return Task.FromResult(result);
    }

    public static Task<List<ISession>> GetSessionsInSector(int sectorX, int sectorY)
    {
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        List<ISession> result = new HashSet<ISession>(sharedObjects.AgentSessions).Where(session =>
        {
            session.GetData(Data.CharInfo, out ICharInfo? targetCharInfo, null);
            if (targetCharInfo == null) return false;
            byte targetSectorX = targetCharInfo.GetCalcPosition.Region.X;
            byte targetSectorY = targetCharInfo.GetCalcPosition.Region.Y;
            return targetSectorX == sectorX && targetSectorY == sectorY;
        }).ToList();
        return Task.FromResult(result);
    }

    public static async Task BroadcastPacketToRegion(int regionId, Packet packet, bool clientIsReady = true)
    {
        await Task.Run(() =>
        {
            ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            foreach (ISession targetSession in new HashSet<ISession>(sharedObjects.AgentSessions))
            {
                targetSession.GetData(Data.CharacterGameReady, out bool characterGameReady, false);

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
        ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        session.GetData(Data.CharInfo, out ICharInfo? charInfo, null);
        if (charInfo == null) return;

        byte sectorX = charInfo.GetCalcPosition.Region.X;
        byte sectorY = charInfo.GetCalcPosition.Region.Y;
        await Task.Run(() =>
        {
            foreach (ISession targetSession in new HashSet<ISession>(sharedObjects.AgentSessions))
            {
                targetSession.GetData(Data.CharacterGameReady, out bool characterGameReady, false);
                if (characterGameReady != clientIsReady) continue;

                targetSession.GetData(Data.CharInfo, out ICharInfo? targetCharInfo, null);
                if (targetCharInfo == null) continue;

                byte targetSectorX = targetCharInfo.GetCalcPosition.Region.X;
                byte targetSectorY = targetCharInfo.GetCalcPosition.Region.Y;
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
            try
            {
                ISharedObjects sharedObjects = ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
                switch (serverType)
                {
                    case ServerType.None:
                        break;
                    case ServerType.DownloadServer:
                        foreach (ISession? session in new ConcurrentHashSet<ISession>(sharedObjects.DownloadSessions))
                        {
                            session.SendToClient(packet);
                        }
                        break;
                    case ServerType.GatewayServer:
                        foreach (ISession? session in new ConcurrentHashSet<ISession>(sharedObjects.GatewaySessions))
                        {
                            session.SendToClient(packet);
                        }
                        break;
                    case ServerType.AgentServer:
                        foreach (ISession? session in new ConcurrentHashSet<ISession>(sharedObjects.AgentSessions))
                        {
                            session.GetData(Data.CharacterGameReady, out bool characterGameReady, false);
                            if (characterGameReady != clientIsReady) continue;
                            session.SendToClient(packet);
                        }

                        break;
                    default:
                        Log.Error("Helper - BroadcastPacket - {0}, {1}", nameof(serverType), serverType);
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Warning("{0}", e.ToString());
                throw;
            }
        });
    }
}