using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;

namespace DuckSoup.Agent;

public class VSRO188_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;
    
    public VSRO188_AgentServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
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