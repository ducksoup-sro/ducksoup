using System.Collections.Generic;
using API;
using API.Database.DuckSoup;
using API.Server;
using NetCoreServer;

namespace DuckSoup.Library.Server;

public interface IServerFactory
{
    IFakeServer Create(Service service, ServerType serverType);

    HashSet<ushort> GetWhitelist(ServerType serverType);
    HashSet<ushort> GetBlacklist(ServerType serverType);

}
