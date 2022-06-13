using API.Database.DuckSoup;

namespace API.Server;

public interface IServerManager : IDisposable
{
    List<IAsyncServer> Servers { get; }

    void Start();
    void Start(bool firstStart);
    void Start(string name);
    void Start(string name, bool firstStart);
    void Start(Service service);
    void Start(Service service, bool firstStart);
    void Stop(string name);
    void Stop(Service service);
    void AddServer(Service service);

    
    Task RegisterModuleHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler);
    Task RegisterClientHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler);
    Task UnregisterModuleHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler);
    Task UnregisterClientHandler(ServerType serverType, ushort msgId, _PacketHandler packetHandler);
}