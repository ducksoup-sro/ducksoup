using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

public class PacketHandler : IPacketHandler
{
    public PacketHandler(HashSet<ushort> clientWhitelist, HashSet<ushort> clientBlacklist)
    {
        SetDefaultHandler(HandleDefault);
        SetBlockHandler(HandleBlock);
        SetDisconnectHandler(HandleDisconnect);
        _clientWhitelist = clientWhitelist;
        _clientBlacklist = clientBlacklist;
    }

    public HashSet<ushort> _clientBlacklist { get; init; }

    public void AddBlacklist(ushort msgId)
    {
        _clientBlacklist.Add(msgId);
    }

    public void RemoveBlacklist(ushort msgId)
    {
        if (_clientBlacklist.Contains(msgId)) _clientBlacklist.Remove(msgId);
    }

    public SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _clientHandlers { get; init; } = new();

    public HashSet<ushort> _clientWhitelist { get; init; }

    public void AddWhitelist(ushort msgId)
    {
        _clientWhitelist.Add(msgId);
    }

    public void RemoveWhitelist(ushort msgId)
    {
        if (_clientWhitelist.Contains(msgId)) _clientWhitelist.Remove(msgId);
    }

    public SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _serverHandlers { get; init; } = new();


    public _PacketHandler<Packet> _blockHandler { get; set; }
    public _PacketHandler<Packet> _defaultHandler { get; set; }
    public _PacketHandler<Packet> _disconnectHandler { get; set; }

    public void SetDefaultHandler(Func<Packet, ISession, Task<Packet>> handler)
    {
        _defaultHandler = new _PacketHandler<Packet>(handler);
    }

    public async Task<Packet> HandleDefault(Packet packet, ISession session)
    {
        packet.ResultType = PacketResultType.Nothing;
        return packet;
    }

    public void SetBlockHandler(Func<Packet, ISession, Task<Packet>> handler)
    {
        _blockHandler = new _PacketHandler<Packet>(handler);
    }

    public async Task<Packet> HandleBlock(Packet packet, ISession session)
    {
        packet.ResultType = PacketResultType.Block;
        return packet;
    }

    public void SetDisconnectHandler(Func<Packet, ISession, Task<Packet>> handler)
    {
        _disconnectHandler = new _PacketHandler<Packet>(handler);
    }

    public async Task<Packet> HandleDisconnect(Packet packet, ISession session)
    {
        packet.ResultType = PacketResultType.Disconnect;
        return packet;
    }

    public void RegisterModuleHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        RegisterModuleHandler(1, handler);
    }

    public void RegisterModuleHandler<T>(int priority, Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        // make sure its not negative
        if (priority < 0) priority = 1;

        var msgId = new T().MsgId;

        if (_serverHandlers.GetValueOrDefault(msgId, null) == null)
            _serverHandlers.TryAdd(msgId, new SortedDictionary<int, IBasePacketHandler>());

        if (_serverHandlers[msgId].ContainsKey(priority))
            foreach (var keyValuePair in _serverHandlers[msgId])
            {
                if (keyValuePair.Key <= priority)
                {
                    priority = keyValuePair.Key + 1;
                    continue;
                }

                if (_serverHandlers[msgId].ContainsKey(priority))
                {
                    priority = keyValuePair.Key + 1;
                    continue;
                }

                break;
            }

        var handlerWrapper = new _PacketHandler<T>(handler);
        _serverHandlers[msgId].TryAdd(priority, handlerWrapper);
    }

    public void UnregisterModuleHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        var msgId = new T().MsgId;
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        var keysToRemove = _serverHandlers[msgId].Where(m => m.Value.Equals(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _serverHandlers[msgId].Remove(key, out var tempObject));
    }

    public void UnregisterAllModuleHandler<T>() where T : Packet, new()
    {
        var msgId = new T().MsgId;
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        _serverHandlers[msgId].Clear();
    }

    public void RegisterClientHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        RegisterClientHandler(1, handler);
    }

    public void RegisterClientHandler<T>(int priority, Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        // make sure its not negative
        if (priority < 0) priority = 1;

        var msgId = new T().MsgId;
        AddWhitelist(msgId);

        if (_clientHandlers.GetValueOrDefault(msgId, null) == null)
            _clientHandlers.TryAdd(msgId, new SortedDictionary<int, IBasePacketHandler>());

        if (_clientHandlers[msgId].ContainsKey(priority))
            foreach (var keyValuePair in _clientHandlers[msgId])
            {
                if (keyValuePair.Key <= priority)
                {
                    priority = keyValuePair.Key + 1;
                    continue;
                }

                if (_clientHandlers[msgId].ContainsKey(priority))
                {
                    priority = keyValuePair.Key + 1;
                    continue;
                }

                break;
            }

        var handlerWrapper = new _PacketHandler<T>(handler);
        _clientHandlers[msgId].TryAdd(priority, handlerWrapper);
    }

    public void UnregisterClientHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        var msgId = new T().MsgId;
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        var keysToRemove = _clientHandlers[msgId].Where(m => m.Value.Equals(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _clientHandlers[msgId].Remove(key, out var tempObject));
    }

    public void UnregisterAllClientHandler<T>() where T : Packet, new()
    {
        var msgId = new T().MsgId;
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        _clientHandlers[msgId].Clear();
    }

    public async Task<Packet> HandleClient(Packet packet, ISession session)
    {
        if (packet.MsgId == 0x9000 || packet.MsgId == 0x5000 || packet.MsgId == 0x2001)
            return await _defaultHandler.Handle(packet, session);
        
        // automatically blocks all packets that are not on the Whitelists!
        if (_clientBlacklist.Contains(packet.MsgId))
            return await _disconnectHandler.Handle(packet, session);

        if (!_clientWhitelist.Contains(packet.MsgId))
            return await _blockHandler.Handle(packet, session);
        
        _clientHandlers.TryGetValue(packet.MsgId, out var handler);

        var outcome = await _defaultHandler.Handle(packet, session);
        if (handler == null) return outcome;

        var last = 0;
        if (handler.Count > 0) last = handler.Last().Key;

        var oldIndex = -1;
        foreach (var packetHandler in handler)
        {
            outcome = await packetHandler.Value.Handle(outcome, session);
            
            if (packetHandler.Key == last)
            {
                await outcome.Build();
                outcome.ToReadOnly();
            }
            
            switch (outcome.ResultType)
            {
                case PacketResultType.Disconnect:
                    if (packetHandler.Key == last) return await _disconnectHandler.Handle(outcome, session);

                    break;
                case PacketResultType.Block:
                    if (packetHandler.Key == last) return await _blockHandler.Handle(outcome, session);

                    break;
                case PacketResultType.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            oldIndex = packetHandler.Key;
        }

        return outcome;
    }

    public async Task<Packet> HandleServer(Packet packet, ISession session)
    {
        _serverHandlers.TryGetValue(packet.MsgId, out var handler);
        var outcome = await _defaultHandler.Handle(packet, session);
        if (handler == null) return outcome;
        var last = 0;
        if (handler.Count > 0) last = handler.Last().Key;

        var oldIndex = -1;
        foreach (var packetHandler in handler)
        {
            outcome = await packetHandler.Value.Handle(outcome, session);

            if (packetHandler.Key == last)
            {
                await outcome.Build();
                outcome.ToReadOnly();
            }
            
            switch (outcome.ResultType)
            {
                case PacketResultType.Disconnect:
                    if (packetHandler.Key == last) return await _disconnectHandler.Handle(outcome, session);

                    break;
                case PacketResultType.Block:
                    if (packetHandler.Key == last) return await _blockHandler.Handle(outcome, session);

                    break;
                case PacketResultType.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            oldIndex = packetHandler.Key;
        }

        return outcome;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}