using System.Collections.ObjectModel;

namespace API.ServiceFactory;

public interface IServiceFactory : IDisposable
{
    T Register<T>(Type service, object provider);
    void Unregister(object provider);
    void Unregister(Type service);
    T Load<T>(Type service);
    RegisteredServiceProvider<object> GetRegistration(Type service);
    Collection<Type> GetKnownServices();
    bool IsProvidedFor(Type service);
}