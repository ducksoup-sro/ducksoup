using API.Database.DuckSoup;
using SilkroadSecurityAPI.Message;

namespace API.Server;

public interface IServerFactory
{
    IFakeServer? Create(Service service, ServerType serverType);

    HashSet<ushort> GetWhitelist(ServerType serverType);
    HashSet<ushort> GetBlacklist(ServerType serverType);
    PacketResultType GetDefaultUnknownClientResult(ServerType serviceServerType);
}