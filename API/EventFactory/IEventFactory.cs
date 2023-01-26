namespace API.EventFactory;

public interface IEventFactory : IDisposable
{
    void Subscribe(string name, Action? handler);
    void Subscribe(string name, Delegate? handler);
    void Unsubscribe(string name, Action? handler);
    void Unsubscribe(string name, Delegate? handler);
    void Publish(string name, params object[] parameters);
}