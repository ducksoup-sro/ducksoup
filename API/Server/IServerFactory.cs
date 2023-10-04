using API.Database.DuckSoup;

namespace API.Server;

public interface IServerFactory
{
    IFakeServer Create(Service service, ServerType serverType);

    HashSet<ushort> GetWhitelist(ServerType serverType);
    HashSet<ushort> GetBlacklist(ServerType serverType);
}