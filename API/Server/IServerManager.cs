using API.Database.DuckSoup;
using PacketLibrary.Handler;
using SilkroadSecurityAPI.Message;

namespace API.Server;

public interface IServerManager : IDisposable
{
    void Start();
    void Start(bool firstStart);
    void Start(string name);
    void Start(string name, bool firstStart);
    void Start(Service service);
    void Start(Service service, bool firstStart);
    void Stop(string name);
    void Stop(Service service);
    void AddServer(Service service);

    
    Task RegisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
    Task RegisterModuleHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
    Task RegisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
    Task RegisterClientHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
    Task UnregisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
    Task UnregisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler) where T : Packet, new();
}