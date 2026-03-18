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

        string originalHost = data.AgentServer.Host;
        ushort originalPort = data.AgentServer.Port;

        string packetHost = data.AgentServer.Host;
        ushort packetPort = data.AgentServer.Port;
        bool isSinglePort = _serverManager.Servers.Any(server =>
            server.Service.ServerType == ServerType.AgentServer &&
            server.Service.SecurityType == Service.SecurityType &&
            server.Service.AutoPort);
        IFakeServer? targetServer = null;

        if (isSinglePort)
        {
            _sharedObjects.AddOrUpdateTokenRoute(data.AgentServerToken, originalHost, originalPort);
            targetServer = _serverManager.Servers.FirstOrDefault(server =>
                server.Service.ServerType == ServerType.AgentServer &&
                server.Service.SecurityType == Service.SecurityType &&
                server.Service.AutoPort);
        }
        else
        {
            targetServer = _serverManager.Servers.FirstOrDefault(agentServer =>
                agentServer.Service.RemotePort == packetPort &&
                agentServer.Service.RemoteMachine_Machine.Address == packetHost);
        }

        if (targetServer == null)
        {
            Log.Verbose("{0} - Connecting to {1}:{2}", Service.Name, data.AgentServer.Host, data.AgentServer.Port);
            return data;
        }

        data.AgentServer.Host = targetServer.Service.LocalMachine_Machine.Address;
        data.AgentServer.Port = (ushort)targetServer.Service.BindPort;

        if (targetServer.Service.SpoofMachine_Machine != null &&
            targetServer.Service.SpoofMachine_Machine.Address != "")
        {
            data.AgentServer.Host = targetServer.Service.SpoofMachine_Machine.Address;
        }

        if (isSinglePort)
        {
            Log.Information("{0} - SinglePort route mapped token {1} => {2}:{3}", Service.Name, data.AgentServerToken,
                originalHost, originalPort);
            Log.Verbose("{0} - Redirecting token {1} to SinglePort {2}:{3}", Service.Name, data.AgentServerToken,
                data.AgentServer.Host, data.AgentServer.Port);
        }

        Log.Debug(
            "{0} - Agent redirect debug | db-remote {1}:{2} | packet {3}:{4} | redirected {5}:{6}",
            Service.Name,
            targetServer.Service.RemoteMachine_Machine.Address,
            targetServer.Service.RemotePort,
            packetHost,
            packetPort,
            data.AgentServer.Host,
            data.AgentServer.Port);

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