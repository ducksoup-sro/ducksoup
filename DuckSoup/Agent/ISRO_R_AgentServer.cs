using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;

namespace DuckSoup.Agent;

public class ISRO_R_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public ISRO_R_AgentServer(Service service) : base(service)
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
        _sharedObjects.AgentSessions.TryRemove(session);
    }
}