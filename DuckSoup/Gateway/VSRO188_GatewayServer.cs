using System;
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
    private readonly IServerManager _serverManager;
    private readonly ISharedObjects _sharedObjects;


    public VSRO188_GatewayServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));

        PacketHandler
            .RegisterModuleHandler<
                SERVER_GATEWAY_LOGIN_RESPONSE>(
                SERVER_GATEWAY_LOGIN_RESPONSE); // Automatically redirect to the AgentServer
        PacketHandler
            .RegisterModuleHandler<
                SERVER_GATEWAY_PATCH_RESPONSE>(
                SERVER_GATEWAY_PATCH_RESPONSE); // Automatically redirect to the DownloadServer
    }

    public override void AddSession(ISession session)
    {
        try
        {
            base.AddSession(session);
            _sharedObjects.GatewaySessions.Add(session);
        }
        catch (Exception exception)
        {
            Log.Error("VSRO188_GatewayServer:46 {0}", exception.ToString());
        }
    }

    public override void RemoveSession(ISession session)
    {
        try
        {
            base.RemoveSession(session);
            bool remove = _sharedObjects.GatewaySessions.TryRemove(session);
            if (!remove)
            {
                Log.Error("DownloadServer error sessionremoval {0}", session.Guid);
            }
        }
        catch (Exception exception)
        {
            Log.Error("VSRO188_GatewayServer:59 {0}", exception.ToString());
        }
    }

    private async Task<Packet> SERVER_GATEWAY_LOGIN_RESPONSE(SERVER_GATEWAY_LOGIN_RESPONSE data, ISession session)
    {
        if (data.Result != 0x01) return data;

        foreach (IFakeServer agentServer in _serverManager.Servers.Where(agentServer =>
                     agentServer.Service.RemotePort == data.AgentServer.Port &&
                     agentServer.Service.RemoteMachine_Machine.Address == data.AgentServer.Host))
        {
            data.AgentServer.Host = agentServer.Service.LocalMachine_Machine.Address;
            data.AgentServer.Port = (ushort)agentServer.Service.BindPort;

            if (agentServer.Service.SpoofMachine_Machine != null &&
                agentServer.Service.SpoofMachine_Machine.Address != "")
            {
                data.AgentServer.Host = agentServer.Service.SpoofMachine_Machine.Address;
            }

        }

        Log.Verbose("{0} - Connecting to {1}:{2}", Service.Name, data.AgentServer.Host, data.AgentServer.Port);

        return data;
    }

    private async Task<Packet> SERVER_GATEWAY_PATCH_RESPONSE(SERVER_GATEWAY_PATCH_RESPONSE data, ISession session)
    {
        if (data.Result == 0x01) return data;

        foreach (IFakeServer download in _serverManager.Servers.Where(download =>
                     download.Service.RemotePort == data.DownloadServer.Port &&
                     download.Service.RemoteMachine_Machine.Address == data.DownloadServer.Host))
        {
            data.DownloadServer.Host = download.Service.LocalMachine_Machine.Address;
            data.DownloadServer.Port = (ushort)download.Service.BindPort;

            if (download.Service.SpoofMachine_Machine != null && download.Service.SpoofMachine_Machine.Address != "")
                data.DownloadServer.Host = download.Service.SpoofMachine_Machine.Address;
        }

        return data;
    }
}