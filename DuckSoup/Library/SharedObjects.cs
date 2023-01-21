using System.Collections.Generic;
using System.Linq;
using API;
using API.Database;
using API.Database.Context;
using API.Database.DuckSoup;
using API.Database.SRO_VT_ACCOUNT;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using API.Session;
using PacketLibrary;

namespace DuckSoup.Library;

public class SharedObjects : ISharedObjects
{
    public static DebugLevel DebugLevel;
    public static string ServerName;

    public SharedObjects()
    {
        ServiceFactory.Register<ISharedObjects>(typeof(ISharedObjects), this);

        ServerName = DatabaseHelper.GetSettingOrDefault("Name", "Filter");
        DebugLevel =
            (DebugLevel)int.Parse(
                DatabaseHelper.GetSettingOrDefault("DebugLevel", ((byte)DebugLevel.Info).ToString()));

        AgentSessions = new HashSet<ISession>();
        DownloadSessions = new HashSet<ISession>();
        GatewaySessions = new HashSet<ISession>();

        Notice = new Dictionary<int, _Notice>();
        RefObjCommon = new Dictionary<int, _RefObjCommon>();
        RefSkill = new Dictionary<int, _RefSkill>();

        using (var context = new API.Database.Context.DuckSoup())
        {
            if (context.Whitelists.ToList().Count == 0)
            {
                foreach (var msgId in DefaultPacketlist.DownloadClientWhitelist)
                {
                    if (!DefaultPacketlist.DownloadClientWhitelistFull.ContainsKey(msgId))
                    {
                        Global.Logger.DebugFormat("Download: Packet 0x{0:X2} not found", msgId);
                        continue;
                    }

                    context.Whitelists.Add(new Whitelist()
                    {
                        MsgId = msgId, Comment = DefaultPacketlist.DownloadClientWhitelistFull[msgId],
                        ServerType = ServerType.DownloadServer
                    });
                }

                foreach (var msgId in DefaultPacketlist.GatewayClientWhitelist)
                {
                    if (!DefaultPacketlist.GatewayClientWhitelistFull.ContainsKey(msgId))
                    {
                        Global.Logger.DebugFormat("Gateway: Packet 0x{0:X2} not found", msgId);
                        continue;
                    }

                    context.Whitelists.Update(new Whitelist
                    {
                        MsgId = msgId, Comment = DefaultPacketlist.GatewayClientWhitelistFull[msgId],
                        ServerType = ServerType.GatewayServer
                    });
                }

                foreach (var msgId in DefaultPacketlist.AgentClientWhitelist)
                {
                    if (!DefaultPacketlist.AgentClientWhitelistFull.ContainsKey(msgId))
                    {
                        Global.Logger.DebugFormat("Agent: Packet 0x{0:X2} not found", msgId);
                        continue;
                    }

                    context.Whitelists.Update(new Whitelist
                    {
                        MsgId = msgId, Comment = DefaultPacketlist.AgentClientWhitelistFull[msgId],
                        ServerType = ServerType.AgentServer
                    });
                }

                context.SaveChanges();
            }
        }

        Load();
    }

    public HashSet<ISession> AgentSessions { get; private set; }
    public HashSet<ISession> DownloadSessions { get; private set; }
    public HashSet<ISession> GatewaySessions { get; private set; }
    public Dictionary<int, _Notice> Notice { get; private set; }
    public Dictionary<int, _RefObjChar> RefObjChar { get; private set; }
    public Dictionary<int, _RefObjCharExtraSkill> RefObjCharExtraSkill { get; private set; }
    public Dictionary<int, _RefObjCommon> RefObjCommon { get; private set; }
    public Dictionary<int, _RefObjItem> RefObjItem { get; private set; }
    public Dictionary<int, _RefObjStruct> RefObjStruct { get; private set; }
    public Dictionary<byte, _RefLevel> RefLevel { get; private set; }
    public Dictionary<int, _RefSkill> RefSkill { get; private set; }

    public void Dispose()
    {
        AgentSessions = null;
        DownloadSessions = null;
        GatewaySessions = null;

        Notice = null;
        RefObjChar = null;
        RefObjCharExtraSkill = null;
        RefObjCommon = null;
        RefObjItem = null;
        RefObjStruct = null;
        RefLevel = null;
        RefSkill = null;
    }

    private void Load()
    {
        if (DebugLevel >= DebugLevel.Info)
        {
            Global.Logger.InfoFormat("{0} - Starting to read and cache the Database. This might take a while!", ServerName);
        }

        using (var db = new SRO_VT_SHARD())
        {
            RefObjChar = db._RefObjChars.ToDictionary(x => x.ID);
            RefObjCharExtraSkill = db._RefObjCharExtraSkills.ToDictionary(x => x.ID);
            RefObjCommon = db._RefObjCommons.ToDictionary(x => x.ID);
            RefObjItem = db._RefObjItems.ToDictionary(x => x.ID);
            RefObjStruct = db._RefObjStructs.ToDictionary(x => x.ID);
            RefLevel = db._RefLevels.ToDictionary(x => x.Lvl);
            RefSkill = db._RefSkills.ToDictionary(x => x.ID);
        }

        using (var db = new SRO_VT_ACCOUNT())
        {
            Notice = db._Notices.ToDictionary(x => x.ID);
        }

        if (DebugLevel < DebugLevel.Info) return;

        Global.Logger.InfoFormat("{0} - {1} Chars loaded.", ServerName, RefObjChar.Count);
        Global.Logger.InfoFormat("{0} - {1} CharExtraSkill loaded.", ServerName, RefObjCharExtraSkill.Count);
        Global.Logger.InfoFormat("{0} - {1} Common loaded.", ServerName, RefObjCommon.Count);
        Global.Logger.InfoFormat("{0} - {1} Items loaded.", ServerName, RefObjItem.Count);
        Global.Logger.InfoFormat("{0} - {1} Structs loaded.", ServerName, RefObjStruct.Count);
        Global.Logger.InfoFormat("{0} - {1} Levels loaded.", ServerName, RefLevel.Count);
        Global.Logger.InfoFormat("{0} - {1} Skills loaded.", ServerName, RefSkill.Count);
        Global.Logger.InfoFormat("{0} - {1} Notices loaded.", ServerName, Notice.Count);
    }
}