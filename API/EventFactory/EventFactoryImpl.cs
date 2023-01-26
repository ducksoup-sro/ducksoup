using API.Exceptions;

namespace API.EventFactory;

public class EventFactoryImpl : IEventFactory
{
    private Dictionary<string, HashSet<Delegate>>? Listeners { get; set; }

    public EventFactoryImpl()
    {
        Listeners = new Dictionary<string, HashSet<Delegate>>();
    }

    public void Subscribe(string name, Action? handler)
    {
        if (handler == null || Listeners == null)
        {
            return;
        }

        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name, new HashSet<Delegate>());
        }

        Listeners[name].Add(handler);
    }
    
    public void Subscribe(string name, Delegate? handler)
    {
        if (handler == null || Listeners == null)
        {
            return;
        }

        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name, new HashSet<Delegate>());
        }

        Listeners[name].Add(handler);
    }
    
    public void Unsubscribe(string name, Action? handler)
    {
        if (handler == null || Listeners == null || !Listeners.ContainsKey(name))
        {
            return;
        }
        
        var keysToRemove = Listeners[name].Where(m => m.Equals(handler)).ToList();
        keysToRemove.ForEach(key => Listeners[name].Remove(key));
    }

    public void Unsubscribe(string name, Delegate? handler)
    {
        if (handler == null || Listeners == null || !Listeners.ContainsKey(name))
        {
            return;
        }
        
        var keysToRemove = Listeners[name].Where(m => m.Equals(handler)).ToList();
        keysToRemove.ForEach(key => Listeners[name].Remove(key));
    }

    public void Publish(string name, params object[] parameters)
    {
        if (Listeners == null || !Listeners.ContainsKey(name))
        {
            return;
        }

        Task.Run(action: () =>
        {
            foreach (var listener in Listeners[name])
            {
                listener.DynamicInvoke(parameters);
            }
        });
    }
    
    public void Dispose()
    {
        if (Listeners == null)
        {
            throw new DisposedException(nameof(EventFactoryImpl));
        }
        
        Listeners.Clear();
        Listeners = null;
    }
}