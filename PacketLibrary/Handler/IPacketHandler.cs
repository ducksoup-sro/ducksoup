using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

// ReSharper disable once InconsistentNaming
public class _PacketHandler<T> : IBasePacketHandler where T : Packet, new()
{
    private readonly Func<T, ISession, Task<Packet>> _handlerAction;

    public _PacketHandler(Func<T, ISession, Task<Packet>> handlerAction)
    {
        _handlerAction = handlerAction;
    }

    public async Task<Packet> Handle(Packet packet, ISession session)
    {
        if (packet.GetType() != typeof(T))
        {
            var x = packet.CreateCopy<T>();
            await x.Read();
            return await _handlerAction(x, session);
        }

        return await _handlerAction((T)packet, session);
    }

    public bool IsEqual<T>(Func<T, ISession, Task<Packet>> otherHandler)
    {
        if (_handlerAction.Equals(otherHandler))
        {
            return true;
        }

        return false;
    }
}

public interface IBasePacketHandler
{
    Task<Packet> Handle(Packet packet, ISession session);
    bool IsEqual<T>(Func<T, ISession, Task<Packet>> otherHandler);
}

public class PacketResult : IDisposable
{
    public PacketResult(PacketResultType packetResultType = PacketResultType.Nothing)
    {
        PacketResultType = packetResultType;
    }

    public PacketResultType PacketResultType { get; init; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public interface IPacketHandler : IDisposable
{
    HashSet<ushort> _clientBlacklist { get; init; }
    SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _clientHandlers { get; init; }
    HashSet<ushort> _clientWhitelist { get; init; }
    SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _serverHandlers { get; init; }

    _PacketHandler<Packet> _blockHandler { get; set; }
    _PacketHandler<Packet> _defaultHandler { get; set; }
    _PacketHandler<Packet> _disconnectHandler { get; set; }
    void AddBlacklist(ushort msgId);
    void RemoveBlacklist(ushort msgId);
    void AddWhitelist(ushort msgId);
    void RemoveWhitelist(ushort msgId);

    void SetDefaultHandler(Func<Packet, ISession, Task<Packet>> handler);
    Task<Packet> HandleDefault(Packet packet, ISession session);
    void SetBlockHandler(Func<Packet, ISession, Task<Packet>> handler);
    Task<Packet> HandleDisconnect(Packet packet, ISession session);
    void SetDisconnectHandler(Func<Packet, ISession, Task<Packet>> handler);
    Task<Packet> HandleBlock(Packet packet, ISession session);

    void RegisterModuleHandler<T>(Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void RegisterModuleHandler<T>(int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void UnregisterModuleHandler<T>(Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void UnregisterAllModuleHandler<T>()
        where T : Packet, new();

    void RegisterClientHandler<T>(Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void RegisterClientHandler<T>(int priority, Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void UnregisterClientHandler<T>(Func<T, ISession, Task<Packet>> handler)
        where T : Packet, new();

    void UnregisterAllClientHandler<T>()
        where T : Packet, new();


    Task<Packet> HandleClient(Packet packet, ISession session);
    Task<Packet> HandleServer(Packet packet, ISession session);
}