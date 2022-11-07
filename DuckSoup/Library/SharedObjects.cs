using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using API;
using API.Database;
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
                (DebugLevel) int.Parse(
                    DatabaseHelper.GetSettingOrDefault("DebugLevel", ((byte) DebugLevel.Info).ToString()));

            AgentSessions = new HashSet<ISession>();
            DownloadSessions = new HashSet<ISession>();
            GatewaySessions = new HashSet<ISession>();

            Notice = new Dictionary<int, C_Notice>();
            RefObjCommon = new Dictionary<int, C_RefObjCommon>();
            RefSkill = new Dictionary<int, C_RefSkill>();

            using (var context = new API.Database.DuckSoup.DuckSoup())
            {
                if (context.Whitelist.ToList().Count == 0)
                {
                    foreach (var msgId in DefaultPacketlist.DownloadClientWhitelist)
                    {
                        if (!DefaultPacketlist.DownloadClientWhitelistFull.ContainsKey(msgId))
                        {
                            Global.Logger.DebugFormat("Download: Packet 0x{0:X2} not found", msgId);
                            continue;
                        }
                        
                        context.Whitelist.AddOrUpdate(new Whitelist()
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
                        
                        context.Whitelist.AddOrUpdate(new Whitelist()
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
                        
                        context.Whitelist.AddOrUpdate(new Whitelist()
                        {
                            MsgId = msgId, Comment = DefaultPacketlist.AgentClientWhitelistFull[msgId],
                            ServerType = ServerType.AgentServer
                        });
                    }

                    context.SaveChanges();
                }
            }

            LoadItems();
            LoadSkills();
            LoadNotices();
        }

        public HashSet<ISession> AgentSessions { get; private set; }
        public HashSet<ISession> DownloadSessions { get; private set; }
        public HashSet<ISession> GatewaySessions { get; private set; }
        public Dictionary<int, C_Notice> Notice { get; private set; }
        public Dictionary<int, C_RefObjCommon> RefObjCommon { get; private set; }
        public Dictionary<int, C_RefSkill> RefSkill { get; private set; }

        public void Dispose()
        {
            AgentSessions = null;
            DownloadSessions = null;
            GatewaySessions = null;

            Notice = null;
            RefObjCommon = null;
            RefSkill = null;
        }

        private void LoadItems()
        {
            if (DebugLevel >= DebugLevel.Info)
            {
                Global.Logger.InfoFormat("{0} - Starting to read RefObjCommon. This might take a while!", ServerName);
            }

            using (var db = new SRO_VT_SHARD())
            {
                RefObjCommon = db.C_RefObjCommon.ToDictionary(x => x.ID);
            }

            if (DebugLevel < DebugLevel.Info) return;

            var count = RefObjCommon.Count;
            Global.Logger.InfoFormat("{0} - {1} Items loaded.", ServerName, count);
        }

        private void LoadSkills()
        {
            if (DebugLevel >= DebugLevel.Info)
            {
                Global.Logger.InfoFormat("{0} - Starting to read RefSkill. This might take a while!", ServerName);
            }

            using (var db = new SRO_VT_SHARD())
            {
                RefSkill = db.C_RefSkill.ToDictionary(x => x.ID);
            }

            if (DebugLevel < DebugLevel.Info) return;

            var count = RefSkill.Count;
            Global.Logger.InfoFormat("{0} - {1} Skills loaded.", ServerName, count);
        }

        private void LoadNotices()
        {
            if (DebugLevel >= DebugLevel.Info)
            {
                Global.Logger.InfoFormat("{0} - Starting to read Notice. This might take a while!", ServerName);
            }

            using (var db = new SRO_VT_ACCOUNT())
            {
                Notice = db.C_Notice.ToDictionary(x => x.ID);
            }

            if (DebugLevel < DebugLevel.Info) return;
            Global.Logger.InfoFormat("{0} - {1} Notices loaded.", ServerName, Notice.Count);
        }
    }