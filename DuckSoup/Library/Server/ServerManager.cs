#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using DuckSoup.Agent;
using DuckSoup.Download;
using DuckSoup.Gateway;

#endregion

namespace DuckSoup.Library.Server
{
    public class ServerManager : IServerManager
    {
        public ServerManager()
        {
            ServiceFactory.Register<IServerManager>(typeof(IServerManager), this);
            Servers = new List<IAsyncServer>();
            using var context = new API.Database.DuckSoup.DuckSoup();
            foreach (var contextService in context.Services.Include(b => b.LocalMachine)
                         .Include(b => b.RemoteMachine).Include(b => b.SpoofMachine))
            {
                AddServer(contextService);
            }

            Start(true);
        }

        public List<IAsyncServer> Servers { get; private set; }

        public void Start()
        {
            Start(false);
        }

        public void Start(bool firstStart)
        {
            foreach (var asyncServer in Servers.Where(asyncServer =>
                         (firstStart && asyncServer.Service.AutoStart) || !firstStart))
            {
                asyncServer.Start();
            }
        }

        public void Start(string name)
        {
            Start(name, false);
        }

        public void Start(string name, bool firstStart)
        {
            foreach (var asyncServer in Servers
                         .Where(asyncServer => asyncServer.Service.Name.ToLower().Equals(name.ToLower()))
                         .Where(asyncServer => (firstStart && asyncServer.Service.AutoStart) || !firstStart))
            {
                asyncServer.Start();
            }
        }

        public void Start(Service service)
        {
            Start(service, false);
        }

        public void Start(Service service, bool firstStart)
        {
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.Equals(service))
                         .Where(asyncServer => (firstStart && asyncServer.Service.AutoStart) || !firstStart))
            {
                asyncServer.Start();
            }
        }

        public void Stop(string name)
        {
            IAsyncServer temp = null;
            foreach (var asyncServer in Servers.Where(asyncServer =>
                         asyncServer.Service.Name.ToLower().Equals(name.ToLower())))
            {
                temp = asyncServer;
            }

            if (temp == null)
            {
                return;
            }

            temp.Dispose();
            Servers.Remove(temp);
        }

        public void Stop(Service service)
        {
            IAsyncServer temp = null;
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.Equals(service)))
            {
                temp = asyncServer;
            }

            if (temp == null)
            {
                return;
            }

            temp.Dispose();
            Servers.Remove(temp);
        }

        public Task RegisterModuleHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler)
        {
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
            {
                asyncServer.PacketHandler.RegisterModuleHandler(msgId, packetHandler);
            }

            return Task.CompletedTask;
        }

        public Task RegisterClientHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler)
        {
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
            {
                asyncServer.PacketHandler.RegisterClientHandler(msgId, packetHandler);
            }

            return Task.CompletedTask;
        }

        public Task UnregisterModuleHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler)
        {
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
            {
                asyncServer.PacketHandler.UnregisterModuleHandler(msgId, packetHandler);
            }

            return Task.CompletedTask;
        }

        public Task UnregisterClientHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler)
        {
            foreach (var asyncServer in Servers.Where(asyncServer => asyncServer.Service.ServerType == serverType))
            {
                asyncServer.PacketHandler.UnregisterClientHandler(msgId, packetHandler);
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if (Servers != null)
            {
                foreach (var asyncServer in Servers)
                {
                    asyncServer.Dispose();
                }
            }

            Servers = null;
        }

        public void AddServer(Service service)
        {
            switch (service.ServerType)
            {
                case ServerType.GatewayServer:
                    var gatewayServer = new GatewayServer(service);
                    Servers.Add(gatewayServer);
                    break;
                case ServerType.DownloadServer:
                    var downloadServer = new DownloadServer(service);
                    Servers.Add(downloadServer);
                    break;
                case ServerType.AgentServer:
                    var agentServer = new AgentServer(service);
                    Servers.Add(agentServer);
                    break;
                case ServerType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}