using API.Database.DuckSoup;
using LanguageExt.Common;
using PacketLibrary.Handler;
using SilkroadSecurityAPI;
using SilkroadSecurityAPI.Message;
using Void = LanguageExt.Pipes.Void;

namespace API.Server;

public interface IServerManager : IDisposable
{
    List<IFakeServer> Servers { get; }

    void Start();
    void Start(bool firstStart);
    void Start(string name);
    void Start(string name, bool firstStart);
    void Start(Service service);
    void Start(Service service, bool firstStart);
    void Stop(string name);
    void Stop(Service service);
    Result<Void> AddServer(Service service);

    IServerFactory GetServiceFactory(SecurityType securityType);

    Task RegisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    Task RegisterModuleHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    Task RegisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    Task RegisterClientHandler<T>(ServerType serverType, int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    Task UnregisterModuleHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    Task UnregisterClientHandler<T>(ServerType serverType, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();
}