using API.ServiceFactory;
using API.Services;

namespace DuckSoup.Library.Services;

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