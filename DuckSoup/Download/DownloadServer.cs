#region

using System;
using System.Collections.Generic;
using System.Linq;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Server;
using PacketLibrary;

#endregion

namespace DuckSoup.Download
{
    public class DownloadServer : AsyncServer
    {
        public DownloadServer(Service service) : base(service)
        {
            SharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));

            using var context = new API.Database.Context.DuckSoup();
            if (!context.Whitelists.Any(s => s.ServerType == ServerType.DownloadServer))
            {
                foreach (var (key, value) in DefaultPacketlist.DownloadClientWhitelistFull)
                {
                    context.Whitelists.Add(new Whitelist
                        {MsgId = key, Comment = value, ServerType = ServerType.DownloadServer});
                }

                context.SaveChanges();
            }

            // Conversion shit because Database actually only supports int not ushort sadge
            var temp1 = context.Whitelists.Where(s => s.ServerType == ServerType.DownloadServer).Select(s => s.MsgId)
                .ToList();
            var temp2 = context.Blacklists.Where(s => s.ServerType == ServerType.DownloadServer).Select(s => s.MsgId)
                .ToList();
            var temp3 = new HashSet<ushort>();
            var temp4 = new HashSet<ushort>();
            foreach (var i in temp1)
            {
                temp3.Add(ushort.Parse(i.ToString()));
            }

            foreach (var i in temp2)
            {
                temp4.Add(ushort.Parse(i.ToString()));
            }

            PacketHandler = new PacketHandler(temp3, temp4);
            
            // ping
            PacketHandler.RegisterClientHandler(0x2002, async (packet, session, _) =>
            {
                session.LastPing = DateTime.Now;
                return new PacketResult();
            });
        }

        private ISharedObjects SharedObjects { get; set; }

        public override void AddSession(ISession session)
        {
            SharedObjects.DownloadSessions.Add(session);
        }

        public override void RemoveSession(ISession session)
        {
            SharedObjects.DownloadSessions.RemoveWhere(sess => sess.ClientGuid == session.ClientGuid);
        }

        public override void Dispose()
        {
            foreach (var downloadSession in SharedObjects
                         .DownloadSessions)
            {
                downloadSession.Stop();
            }

            SharedObjects = null;

            base.Dispose();
        }
    }
}