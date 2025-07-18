using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Handler;

public class PacketHandler : IPacketHandler
{
    public PacketHandler(HashSet<ushort> clientWhitelist, HashSet<ushort> clientBlacklist,
        PacketResultType unknownClientResult = PacketResultType.Block)
    {
        SetDefaultHandler(HandleDefault);
        SetBlockHandler(HandleBlock);
        SetDisconnectHandler(HandleDisconnect);
        SetUnknownClientHandler(unknownClientResult);
        _clientWhitelist = clientWhitelist;
        _clientBlacklist = clientBlacklist;
    }

    public _PacketHandler<Packet> _unknownClientHandler { get; set; }

    public HashSet<ushort> _clientBlacklist { get; init; }

    public void AddBlacklist(ushort msgId)
    {
        _clientBlacklist.Add(msgId);
    }

    public void RemoveBlacklist(ushort msgId)
    {
        if (_clientBlacklist.Contains(msgId)) _clientBlacklist.Remove(msgId);
    }

    public SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _clientHandlers { get; init; } = new SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>>();

    public HashSet<ushort> _clientWhitelist { get; init; }

    public void AddWhitelist(ushort msgId)
    {
        _clientWhitelist.Add(msgId);
    }

    public void RemoveWhitelist(ushort msgId)
    {
        if (_clientWhitelist.Contains(msgId)) _clientWhitelist.Remove(msgId);
    }

    public SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>> _serverHandlers { get; init; } = new SortedDictionary<ushort, SortedDictionary<int, IBasePacketHandler>>();


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

        ushort msgId = new T().MsgId;

        if (_serverHandlers.GetValueOrDefault(msgId, null) == null)
            _serverHandlers.TryAdd(msgId, new SortedDictionary<int, IBasePacketHandler>());

        if (_serverHandlers[msgId].ContainsKey(priority))
            foreach (KeyValuePair<int, IBasePacketHandler> keyValuePair in _serverHandlers[msgId])
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

        _PacketHandler<T> handlerWrapper = new _PacketHandler<T>(handler);
        _serverHandlers[msgId].TryAdd(priority, handlerWrapper);
    }

    public void UnregisterModuleHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        ushort msgId = new T().MsgId;
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        List<int> keysToRemove = _serverHandlers[msgId].Where(m => m.Value.IsEqual(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _serverHandlers[msgId].Remove(key, out IBasePacketHandler? tempObject));
    }

    public void UnregisterAllModuleHandler<T>() where T : Packet, new()
    {
        ushort msgId = new T().MsgId;
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

        ushort msgId = new T().MsgId;
        AddWhitelist(msgId);

        if (_clientHandlers.GetValueOrDefault(msgId, null) == null)
            _clientHandlers.TryAdd(msgId, new SortedDictionary<int, IBasePacketHandler>());

        if (_clientHandlers[msgId].ContainsKey(priority))
            foreach (KeyValuePair<int, IBasePacketHandler> keyValuePair in _clientHandlers[msgId])
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

        _PacketHandler<T> handlerWrapper = new _PacketHandler<T>(handler);
        _clientHandlers[msgId].TryAdd(priority, handlerWrapper);
    }

    public void UnregisterClientHandler<T>(Func<T, ISession, Task<Packet>> handler) where T : Packet, new()
    {
        ushort msgId = new T().MsgId;
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        List<int> keysToRemove = _clientHandlers[msgId].Where(m => m.Value.IsEqual(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _clientHandlers[msgId].Remove(key, out IBasePacketHandler? tempObject));
    }

    public void UnregisterAllClientHandler<T>() where T : Packet, new()
    {
        ushort msgId = new T().MsgId;
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        _clientHandlers[msgId].Clear();
    }

    public async Task<Packet> HandleClient(Packet packet, ISession session)
    {
        if (packet.MsgId == 0x9000 || packet.MsgId == 0x5000 || packet.MsgId == 0x2001)
            return await _defaultHandler.Handle(packet, session);

        if (_clientBlacklist.Contains(packet.MsgId))
            return await _disconnectHandler.Handle(packet, session);

        // automatically decides what to do with the clients
        if (!_clientWhitelist.Contains(packet.MsgId))
            return await _unknownClientHandler.Handle(packet, session);

        _clientHandlers.TryGetValue(0x0, out SortedDictionary<int, IBasePacketHandler>? catchAllHandler);
        _clientHandlers.TryGetValue(packet.MsgId, out SortedDictionary<int, IBasePacketHandler>? clientHandlers);


        Packet outcome = await _defaultHandler.Handle(packet, session);
        if (catchAllHandler == null && clientHandlers == null) return outcome;

        SortedDictionary<int, IBasePacketHandler> handler = new SortedDictionary<int, IBasePacketHandler>();
        int index = 0;
        if (clientHandlers != null)
        {
            foreach (KeyValuePair<int, IBasePacketHandler> basePacketHandler in clientHandlers)
            {
                handler.Add(index++, basePacketHandler.Value);
            }
        }

        if (catchAllHandler != null)
        {
            foreach (KeyValuePair<int, IBasePacketHandler> basePacketHandler in catchAllHandler)
            {
                handler.Add(index++, basePacketHandler.Value);
            }
        }

        int last = 0;
        if (handler.Count > 0) last = handler.Last().Key;

        int oldIndex = -1;
        foreach (KeyValuePair<int, IBasePacketHandler> packetHandler in handler)
        {
            outcome = await packetHandler.Value.Handle(outcome, session);
            // reset reader position, in case it was read before
            outcome.SetReaderPosition(0);

            if (packetHandler.Key != last)
            {
                continue;
            }

            await outcome.Build();
            outcome.ToReadOnly();

            switch (outcome.ResultType)
            {
                case PacketResultType.Disconnect:
                    return await _disconnectHandler.Handle(outcome, session);
                case PacketResultType.Block:
                    return await _blockHandler.Handle(outcome, session);
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
        _serverHandlers.TryGetValue(0x0, out SortedDictionary<int, IBasePacketHandler>? catchAllHandler);
        _serverHandlers.TryGetValue(packet.MsgId, out SortedDictionary<int, IBasePacketHandler>? serverHandlers);


        Packet outcome = await _defaultHandler.Handle(packet, session);
        if (catchAllHandler == null && serverHandlers == null) return outcome;

        SortedDictionary<int, IBasePacketHandler> handler = new SortedDictionary<int, IBasePacketHandler>();
        int index = 0;
        if (serverHandlers != null)
        {
            foreach (KeyValuePair<int, IBasePacketHandler> basePacketHandler in serverHandlers)
            {
                handler.Add(index++, basePacketHandler.Value);
            }
        }

        if (catchAllHandler != null)
        {
            foreach (KeyValuePair<int, IBasePacketHandler> basePacketHandler in catchAllHandler)
            {
                handler.Add(index++, basePacketHandler.Value);
            }
        }


        // _serverHandlers.TryGetValue(packet.MsgId, out var handler);
        //
        // var outcome = await _defaultHandler.Handle(packet, session);
        // if (handler == null) return outcome;

        int last = 0;
        if (handler.Count > 0) last = handler.Last().Key;

        int oldIndex = -1;
        foreach (KeyValuePair<int, IBasePacketHandler> packetHandler in handler)
        {
            outcome = await packetHandler.Value.Handle(outcome, session);
            // reset reader position, in case it was read before
            outcome.SetReaderPosition(0);

            if (packetHandler.Key != last)
            {
                continue;
            }

            await outcome.Build();
            outcome.ToReadOnly();

            switch (outcome.ResultType)
            {
                case PacketResultType.Disconnect:
                    return await _disconnectHandler.Handle(outcome, session);
                case PacketResultType.Block:
                    return await _blockHandler.Handle(outcome, session);
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

    public void SetUnknownClientHandler(PacketResultType resultType)
    {
        _unknownClientHandler = resultType switch
        {
            PacketResultType.Disconnect => _disconnectHandler,
            PacketResultType.Block => _blockHandler,
            PacketResultType.Nothing => _defaultHandler,
            _ => _blockHandler
        };
    }
}