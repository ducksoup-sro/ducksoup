using System.Linq;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;
using PacketLibrary.ISRO_R.Gateway.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Gateway;

public class ISRO_R_GatewayServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;
    private readonly IServerManager _serverManager;

    public ISRO_R_GatewayServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));

        PacketHandler.RegisterModuleHandler<SERVER_GATEWAY_LOGIN_RESPONSE>(SERVER_GATEWAY_LOGIN_RESPONSE); // Automatically redirect to the AgentServer

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
                     agentServer.Service.RemotePort == data.Port &&
                     agentServer.Service.RemoteMachine_Machine.Address == data.Host))
        {
            data.Host = agentServer.Service.LocalMachine_Machine.Address;
            data.Port = (ushort)agentServer.Service.BindPort;

            if (agentServer.Service.SpoofMachine_Machine != null && agentServer.Service.SpoofMachine_Machine.Address != "")
            {
                data.Host = agentServer.Service.SpoofMachine_Machine.Address;
            }
        }

        return data;
    }
}