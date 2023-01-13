using API.Database.Services;
using API.ServiceFactory;

namespace DuckSoup.Library.Database.Services;

public class Service<T> : IService<T>
{
    protected Service()
    {
        Register();
    }

    public void Register()
    {
        ServiceFactory.Register<T>(typeof(T), this);
    }
}