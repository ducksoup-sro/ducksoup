using API;
using API.Database.DuckSoup;

namespace DuckSoup.Library.Server;

public interface IServerFactory
{
    FakeServer Create(Service service, ServerType serverType);
}
