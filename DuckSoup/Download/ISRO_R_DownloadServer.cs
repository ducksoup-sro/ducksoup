using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;

namespace DuckSoup.Download;

public class ISRO_R_DownloadServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public ISRO_R_DownloadServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
    }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        _sharedObjects.DownloadSessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        _sharedObjects.DownloadSessions.TryRemove(session);
    }
}