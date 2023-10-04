using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Gateway.Server;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Gateway;

public class VSRO188_GatewayServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;
    private readonly IServerManager _serverManager;


    public VSRO188_GatewayServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));
        
        PacketHandler.RegisterModuleHandler<SERVER_GATEWAY_LOGIN_RESPONSE>(SERVER_GATEWAY_LOGIN_RESPONSE); // Automatically redirect to the AgentServer
        PacketHandler.RegisterModuleHandler<SERVER_GATEWAY_PATCH_RESPONSE>(SERVER_GATEWAY_PATCH_RESPONSE); // Automatically redirect to the DownloadServer
    }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        _sharedObjects.GatewaySessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        if (_sharedObjects.GatewaySessions.Contains(session))
        {
            _sharedObjects.GatewaySessions.Remove(session);
        }
    }
    
    private async Task<Packet> SERVER_GATEWAY_LOGIN_RESPONSE(SERVER_GATEWAY_LOGIN_RESPONSE data, ISession session)
    {
        if (data.Result != 0x01)
        {
            return data;
        }
        
        foreach (var agentServer in _serverManager.Servers.Where(agentServer =>
                     agentServer.Service.RemotePort == data.AgentServer.Port &&
                     agentServer.Service.RemoteMachine_Machine.Address == data.AgentServer.Host))
        {
            data.AgentServer.Host = agentServer.Service.LocalMachine_Machine.Address;
            data.AgentServer.Port = (ushort)agentServer.Service.BindPort;

            if (agentServer.Service.SpoofMachine_Machine != null && agentServer.Service.SpoofMachine_Machine.Address != "")
            {
                data.AgentServer.Host = agentServer.Service.SpoofMachine_Machine.Address;
            }
        }

        return data;
    }

    private async Task<Packet> SERVER_GATEWAY_PATCH_RESPONSE(SERVER_GATEWAY_PATCH_RESPONSE data, ISession session)
    {
        if (data.Result == 0x01)
        {
            return data;
        }
        
        foreach (var download in _serverManager.Servers.Where(download =>
                     download.Service.RemotePort == data.DownloadServer.Port &&
                     download.Service.RemoteMachine_Machine.Address == data.DownloadServer.Host))
        {
            data.DownloadServer.Host = download.Service.LocalMachine_Machine.Address;
            data.DownloadServer.Port = (ushort)download.Service.BindPort;
        
            if (download.Service.SpoofMachine_Machine != null && download.Service.SpoofMachine_Machine.Address != "")
            {
                data.DownloadServer.Host = download.Service.SpoofMachine_Machine.Address;
            }
        }

        return data;
    }
}