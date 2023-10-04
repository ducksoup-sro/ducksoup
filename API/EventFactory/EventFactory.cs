using API.Exceptions;

namespace API.EventFactory;

public static class EventFactory
{
    private static EventFactoryImpl? _eventFactoryImpl = new();

    public static void Subscribe(string name, Action? handler)
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Subscribe(name, handler);
    }

    public static void Subscribe(string name, Delegate? handler)
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Subscribe(name, handler);
    }

    public static void Unsubscribe(string name, Action? handler)
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Unsubscribe(name, handler);
    }

    public static void Unsubscribe(string name, Delegate? handler)
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Unsubscribe(name, handler);
    }

    public static void Publish(string name, params object[] parameters)
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Publish(name, parameters);
    }


    public static void Dispose()
    {
        if (_eventFactoryImpl == null) throw new DisposedException(nameof(ServiceFactory));

        _eventFactoryImpl.Dispose();
        _eventFactoryImpl = null;
    }
}