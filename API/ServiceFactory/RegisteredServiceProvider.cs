namespace API.ServiceFactory;

public class RegisteredServiceProvider<T> : IDisposable
{
    public RegisteredServiceProvider(Type service, T provider)
    {
        Service = service;
        Provider = provider;
    }

    public Type Service { get; set; }
    public T Provider { get; private set; }

    public void Dispose()
    {
        Service = null!;
        Provider = default!;
    }
}