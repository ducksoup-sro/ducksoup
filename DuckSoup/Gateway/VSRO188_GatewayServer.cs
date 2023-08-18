using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Gateway.Server;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Gateway;

public class VSRO188_GatewayServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public VSRO188_GatewayServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
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
}