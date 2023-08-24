using System;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent;

public class VSRO188_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;
    
    public VSRO188_AgentServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        
        PacketHandler.RegisterModuleHandler<SERVER_On3013>(SERVER_On3013); // Automatically redirect to the DownloadServer
    }

    private async Task<Packet> SERVER_On3013(SERVER_On3013 data, ISession session)
    {
        Global.Logger.Info($"Debug 3013 Size: {data.GetBytes().Length}");
        return data;
    }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        _sharedObjects.AgentSessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        if (_sharedObjects.AgentSessions.Contains(session))
        {
            _sharedObjects.AgentSessions.Remove(session);
        }
    }
}