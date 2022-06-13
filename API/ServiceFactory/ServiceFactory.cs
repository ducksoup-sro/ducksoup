using System.Collections.ObjectModel;
using API.Exceptions;
using API.ServiceFactory.Exceptions;

namespace API.ServiceFactory;

public static class ServiceFactory
{
    private static ServiceFactoryImpl? _serviceFactoryImpl = new ServiceFactoryImpl();

    public static T Register<T>(Type service, object provider)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        return _serviceFactoryImpl.Register<T>(service, provider);
    }
    
    public static void Unregister(object provider)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        _serviceFactoryImpl.Unregister(provider);
    }

    public static void Unregister(Type service)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        _serviceFactoryImpl.Unregister(service);
    }

    public static T Load<T>(Type service)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        if (!string.Equals(typeof(T).ToString(), service.ToString(), StringComparison.CurrentCultureIgnoreCase))
        {
            throw new ServiceTypeMismatchException(typeof(T).ToString(), service.ToString());
        }

        return _serviceFactoryImpl.Load<T>(service);
    }

    public static RegisteredServiceProvider<object> GetRegistration(Type service)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        return _serviceFactoryImpl.GetRegistration(service);
    }

    public static Collection<Type> GetKnownServices()
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        return _serviceFactoryImpl.GetKnownServices();
    }

    public static bool IsProvidedFor(Type service)
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        return _serviceFactoryImpl.IsProvidedFor(service);
    }

    public static void Dispose()
    {
        if (_serviceFactoryImpl == null)
        {
            throw new DisposedException(nameof(ServiceFactory));
        }

        _serviceFactoryImpl.Dispose();
        _serviceFactoryImpl = null;
    }
}