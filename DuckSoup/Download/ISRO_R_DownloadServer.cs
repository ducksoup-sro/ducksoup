using API.Database.DuckSoup;
using DuckSoup.Library.Server;

namespace DuckSoup.Download;

public class ISRO_R_DownloadServer : FakeServer
{
    public ISRO_R_DownloadServer(Service service) : base(service)
    {
    }
}