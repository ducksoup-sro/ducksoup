using System.Collections.ObjectModel;
using API.Exceptions;
using API.ServiceFactory.Exceptions;

namespace API.ServiceFactory;

public class ServiceFactoryImpl : IServiceFactory
{
    public ServiceFactoryImpl()
    {
        Providers = new Dictionary<Type, RegisteredServiceProvider<object>>();
    }

    private Dictionary<Type, RegisteredServiceProvider<object>>? Providers { get; set; }

    public T Register<T>(Type service, object provider)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        Providers.Add(service, new RegisteredServiceProvider<object>(service, provider));

        return (T)provider;
    }

    public void Unregister(object provider)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        Type? service = null;
        foreach ((Type key, RegisteredServiceProvider<object> value) in Providers)
        {
            if (value.Provider == provider)
                service = key;
        }

        if (service != null) Providers.Remove(service);
    }

    public void Unregister(Type service)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        if (Providers.ContainsKey(service)) Providers.Remove(service);
    }

    public T Load<T>(Type service)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        if (!Providers.ContainsKey(service)) throw new ServiceNotRegisteredException(service.Name);

        return (T)Providers[service].Provider;
    }

    public RegisteredServiceProvider<object> GetRegistration(Type service)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        return Providers[service];
    }

    public Collection<Type> GetKnownServices()
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        Collection<Type> result = new Collection<Type>();
        foreach ((Type key, RegisteredServiceProvider<object> _) in Providers)
        {
            result.Add(key);
        }

        return result;
    }

    public bool IsProvidedFor(Type service)
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        return Providers.ContainsKey(service);
    }

    public void Dispose()
    {
        if (Providers == null) throw new DisposedException(nameof(ServiceFactoryImpl));

        foreach (KeyValuePair<Type, RegisteredServiceProvider<object>> registeredServiceProvider in Providers)
        {
            registeredServiceProvider.Value.Dispose();
        }

        Providers = null;
    }
}