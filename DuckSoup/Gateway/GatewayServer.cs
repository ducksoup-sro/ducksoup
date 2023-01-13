#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Server;
using PacketLibrary;
using SilkroadSecurityAPI;

#endregion

#pragma warning disable 1998

namespace DuckSoup.Gateway
{
    public class GatewayServer : AsyncServer
    {
        public GatewayServer(Service service) : base(service)
        {
            SharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
            ServerManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));

            using (var context = new API.Database.Context.DuckSoup())
            {
                if (!context.Whitelists.Any(s => s.ServerType == ServerType.GatewayServer))
                {
                    foreach (var (key, value) in DefaultPacketlist.GatewayClientWhitelistFull)
                    {
                        context.Whitelists.Add(new Whitelist
                            {MsgId = key, Comment = value, ServerType = ServerType.GatewayServer});
                    }

                    context.SaveChanges();
                }

                // Conversion shit because Database actually only supports int not ushort sadge
                var temp1 = context.Whitelists.Where(s => s.ServerType == ServerType.GatewayServer).Select(s => s.MsgId)
                    .ToList();
                var temp2 = context.Blacklists.Where(s => s.ServerType == ServerType.GatewayServer).Select(s => s.MsgId)
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
            }

            // ping
            PacketHandler.RegisterClientHandler(0x2002, async (packet, session, _) =>
            {
                session.LastPing = DateTime.Now;
                return new PacketResult();
            });
            
            PacketHandler.RegisterModuleHandler(0xA102,
                SERVER_GATEWAY_LOGIN_RESPONSE); // Automatically redirect to the AgentServer
            PacketHandler.RegisterModuleHandler(0xA100,
                SERVER_GATEWAY_PATCH_RESPONSE); // Automatically redirect to the DownloadServer
            PacketHandler.RegisterModuleHandler(0xA104, SERVER_GATEWAY_NOTICE_RESPONSE); // Replaces the Notices
        }

        private ISharedObjects SharedObjects { get; set; }
        private IServerManager ServerManager { get; set; }

        public override void AddSession(ISession session)
        {
            base.AddSession(session);
            SharedObjects.GatewaySessions.Add(session);
        }

        public override void RemoveSession(ISession session)
        {
            base.RemoveSession(session);
            if (SharedObjects.GatewaySessions.Contains(session))
            {
                SharedObjects.GatewaySessions.Remove(session);
            }
        }

        public override void Dispose()
        {
            foreach (var gatewaySession in SharedObjects.GatewaySessions)
            {
                gatewaySession.Stop();
            }

            SharedObjects = null;
            ServerManager = null;

            base.Dispose();
        }

        private async Task<PacketResult> SERVER_GATEWAY_PATCH_RESPONSE(Packet packet, ISession session, object obj)
        {
            var overridePacket = new Packet(0xA100, packet.Encrypted, packet.Massive);
            var result = packet.ReadUInt8(); // 1	byte	result
            overridePacket.WriteUInt8(result);
            if (result == 0x02)
            {
                var errorCode = packet.ReadUInt8(); // 1	byte	errorCode
                overridePacket.WriteUInt8(errorCode);

                if (errorCode == 0x02)
                {
                    var bindPort = 0;
                    var bindAddress = "0.0.0.0";

                    var downloadServerIp = packet.ReadAscii(); // *	string	DownloadServer.IP
                    var downloadServerPort = packet.ReadUInt16(); //2	ushort	DownloadServer.Port
                    var downloadServerCurVersion = packet.ReadUInt32(); //4	uint	DownloadServer.CurVersion

                    // finds the according downloadServer to the given port and address and writes the redirect packet
                    foreach (var downloadServer in ServerManager.Servers.Where(agentServer =>
                                 agentServer.Service.RemotePort == downloadServerPort &&
                                 agentServer.Service.RemoteMachine_Machine.Address == downloadServerIp))
                    {
                        bindAddress = downloadServer.Service.LocalMachine_Machine.Address;
                        bindPort = downloadServer.Service.BindPort;

                        if (downloadServer.Service.SpoofMachine_Machine != null &&
                            downloadServer.Service.SpoofMachine_Machine.Address != "")
                        {
                            bindAddress = downloadServer.Service.SpoofMachine_Machine.Address;
                        }
                    }

                    overridePacket.WriteAscii(bindAddress);
                    overridePacket.WriteUInt16(bindPort);
                    overridePacket.WriteUInt32(downloadServerCurVersion);

                    while (true)
                    {
                        var hasEntries = packet.ReadBool(); // 1	bool hasEntries
                        overridePacket.WriteBool(hasEntries);
                        if (!hasEntries)
                            break;


                        overridePacket.WriteUInt32(packet.ReadUInt32()); //4	uint	file.ID
                        overridePacket.WriteAscii(packet.ReadAscii()); //    *	string	file.Name
                        overridePacket.WriteAscii(packet.ReadAscii()); //    *	string	file.Path
                        overridePacket.WriteUInt32(packet.ReadUInt32()); //4	uint	file.Length //in bytes
                        overridePacket.WriteBool(packet.ReadBool()); //1	bool	file.ToBePacked //into pk2
                    }
                }
            }

            return new PacketResult(overridePacket, PacketResultType.Override);
        }

        private async Task<PacketResult> SERVER_GATEWAY_LOGIN_RESPONSE(Packet packet, ISession session, object obj)
        {
            var flag = packet.ReadUInt8();

            // Block everything else
            if (flag != 0x01)
                return new PacketResult();

            var token = packet.ReadUInt32();
            var remoteAddress = packet.ReadAscii(); // host
            var remotePort = packet.ReadUInt16(); // host

            var bindPort = 0;
            var bindAddress = "0.0.0.0";

            // finds the according agentServer to the given port and address and writes the redirect packet
            foreach (var agentServer in ServerManager.Servers.Where(agentServer =>
                         agentServer.Service.RemotePort == remotePort &&
                         agentServer.Service.RemoteMachine_Machine.Address == remoteAddress))
            {
                bindAddress = agentServer.Service.LocalMachine_Machine.Address;
                bindPort = agentServer.Service.BindPort;

                if (agentServer.Service.SpoofMachine_Machine != null && agentServer.Service.SpoofMachine_Machine.Address != "")
                {
                    bindAddress = agentServer.Service.SpoofMachine_Machine.Address;
                }
            }

            if (Library.SharedObjects.DebugLevel >= DebugLevel.Debug)
                Global.Logger.DebugFormat("{0} - Redirect - source {1}:{2} - target {3}:{4}",
                    Library.SharedObjects.ServerName, remoteAddress, remotePort, bindAddress, bindPort);

            // create a new Packet and override the old client before sending to client
            var redirectPacket = new Packet(0xA102, true);
            redirectPacket.WriteUInt8(0x01);
            redirectPacket.WriteUInt32(token);
            redirectPacket.WriteAscii(bindAddress);
            redirectPacket.WriteUInt16((ushort) bindPort);


            Task.Run(async () =>
            {
                await Task.Delay(2000);
                session.Stop();
            });
            return new PacketResult(redirectPacket, PacketResultType.Override);
        }

        private async Task<PacketResult> SERVER_GATEWAY_NOTICE_RESPONSE(Packet packet, ISession session, object obj)
        {
            var newPacket = new Packet(packet.Opcode, packet.Encrypted, packet.Massive);
            newPacket.WriteByte((byte) SharedObjects.Notice.Count);
            foreach (var (_, value) in SharedObjects.Notice)
            {
                newPacket.WriteAscii(value.Subject);
                newPacket.WriteAscii(value.Article);
                newPacket.WriteUInt16((ushort) value.EditDate.Year);
                newPacket.WriteUInt16((ushort) value.EditDate.Month);
                newPacket.WriteUInt16((ushort) value.EditDate.Day);
                newPacket.WriteUInt16((ushort) value.EditDate.Hour);
                newPacket.WriteUInt16((ushort) value.EditDate.Minute);
                newPacket.WriteUInt16((ushort) value.EditDate.Second);
                newPacket.WriteUInt32((uint) value.EditDate.Millisecond);
            }

            return new PacketResult(newPacket, PacketResultType.Override);
        }
    }
}