#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.Server;
using API.Session;
using SilkroadSecurityAPI;

#endregion

#pragma warning disable 1998

namespace DuckSoup.Library.Server;

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
    public SortedDictionary<ushort, SortedDictionary<int, _PacketHandler>> _clientHandlers { get; init; } = new();
    public HashSet<ushort> _clientWhitelist { get; init; }
    public SortedDictionary<ushort, SortedDictionary<int, _PacketHandler>> _serverHandlers { get; init; } = new();

    public _PacketHandler _blockHandler { get; set; }
    public _PacketHandler _defaultHandler { get; set; }
    public _PacketHandler _disconnectHandler { get; set; }

    public void RegisterModuleHandler(ushort msgId, _PacketHandler handler)
    {
        RegisterModuleHandler(msgId, 1, handler);
    }

    public void RegisterModuleHandler(ushort msgId, int priority, _PacketHandler handler)
    {
        // make sure its not negative
        if (priority < 0)
        {
            priority = 1;
        }

        if (_serverHandlers.GetValueOrDefault(msgId, null) == null)
        {
            _serverHandlers.TryAdd(msgId, new SortedDictionary<int, _PacketHandler>());
        }


        if (_serverHandlers[msgId].ContainsKey(priority))
        {
            foreach (var keyValuePair in _serverHandlers[msgId])
            {
                if (keyValuePair.Key <= priority)
                {
                    continue;
                }

                if (_serverHandlers[msgId].ContainsKey(keyValuePair.Key + 1))
                {
                    continue;
                }

                priority = keyValuePair.Key + 1;
                break;
            }
        }

        _serverHandlers[msgId].TryAdd(priority, handler);
    }

    public void UnregisterModuleHandler(ushort msgId, _PacketHandler handler)
    {
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        var keysToRemove = _serverHandlers[msgId].Where(m => m.Value.Equals(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _serverHandlers[msgId].Remove(key, out var tempObject));
    }

    public void UnregisterAllModuleHandler(ushort msgId)
    {
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        _serverHandlers[msgId].Clear();
    }

    public void RegisterClientHandler(ushort msgId, _PacketHandler handler)
    {
        RegisterClientHandler(msgId, 1, handler);
    }

    public void RegisterClientHandler(ushort msgId, int priority, _PacketHandler handler)
    {
        // make sure its not negative
        if (priority < 0)
        {
            priority = 1;
        }

        if (_clientHandlers.GetValueOrDefault(msgId, null) == null)
        {
            _clientHandlers.TryAdd(msgId, new SortedDictionary<int, _PacketHandler>());
        }

        if (_clientHandlers[msgId].ContainsKey(priority))
        {
            foreach (var keyValuePair in _clientHandlers[msgId])
            {
                if (keyValuePair.Key <= priority)
                {
                    continue;
                }

                if (_clientHandlers[msgId].ContainsKey(keyValuePair.Key + 1))
                {
                    continue;
                }

                priority = keyValuePair.Key + 1;
                break;
            }
        }

        _clientHandlers[msgId].TryAdd(priority, handler);
    }

    public void UnregisterClientHandler(ushort msgId, _PacketHandler handler)
    {
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        var keysToRemove = _clientHandlers[msgId].Where(m => m.Value.Equals(handler)).Select(c => c.Key).ToList();
        keysToRemove.ForEach(key => _clientHandlers[msgId].Remove(key, out var tempObject));
    }

    public void UnregisterAllClientHandler(ushort msgId)
    {
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        _clientHandlers[msgId].Clear();
    }

    public void SetDefaultHandler(_PacketHandler handler)
    {
        _defaultHandler = handler;
    }

    public async Task<PacketResult> HandleDefault(Packet packet, ISession session, PacketData data)
    {
        return new PacketResult(data);
    }

    public void SetBlockHandler(_PacketHandler handler)
    {
        _blockHandler = handler;
    }

    public async Task<PacketResult> HandleDisconnect(Packet packet, ISession session, PacketData data)
    {
        return new PacketResult(data, PacketResultType.Disconnect);
    }

    public void SetDisconnectHandler(_PacketHandler handler)
    {
        _disconnectHandler = handler;
    }

    public async Task<PacketResult> HandleBlock(Packet packet, ISession session, PacketData data)
    {
        return new PacketResult(data, PacketResultType.Block);
    }

    public async Task<PacketResult> HandleClient(Packet packet, ISession session)
    {
        if (packet.Opcode == 0x9000 || packet.Opcode == 0x5000 || packet.Opcode == 0x2001)
            return await _defaultHandler(packet, session, null);

        // automatically blocks all packets that are not on the whitelist!
        if (_clientBlacklist.Contains(packet.Opcode))
            return await _disconnectHandler(packet, session, null);

        if (!_clientWhitelist.Contains(packet.Opcode))
            return await _blockHandler(packet, session, null);

        _clientHandlers.TryGetValue(packet.Opcode, out var handler);

        var outcome = await _defaultHandler(packet, session, null);
        if (handler == null) return outcome;
        var tempPacket = packet;
        var last = 0;
        if (handler.Count > 0)
        {
            last = handler.Last().Key;
        }

        var oldIndex = -1;
        foreach (var packetHandler in handler)
        {
            tempPacket = new Packet(tempPacket);
            tempPacket.ToReadOnly();

            outcome = await packetHandler.Value.Invoke(tempPacket, session, new PacketData(oldIndex, outcome.Data));
            switch (outcome.PacketResultType)
            {
                case PacketResultType.Override when outcome.OverridePacket != null:
                    tempPacket = outcome.OverridePacket;
                    break;
                case PacketResultType.Disconnect:
                    if (packetHandler.Key == last)
                    {
                        return await _disconnectHandler(packet, session, new PacketData(oldIndex, outcome.Data));
                    }

                    break;
                case PacketResultType.Block:
                    if (packetHandler.Key == last)
                    {
                        return await _blockHandler(packet, session, new PacketData(oldIndex, outcome.Data));
                    }

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

    public async Task<PacketResult> HandleServer(Packet packet, ISession session)
    {
        _serverHandlers.TryGetValue(packet.Opcode, out var handler);
        var outcome = await _defaultHandler(packet, session, null);
        if (handler == null) return outcome;
        var tempPacket = packet;
        var last = 0;
        if(handler.Count > 0) {
            last = handler.Last().Key;
        }        
        var oldIndex = -1;
        foreach (var packetHandler in handler)
        {
            tempPacket = new Packet(tempPacket);
            tempPacket.ToReadOnly();

            outcome = await packetHandler.Value.Invoke(tempPacket, session, new PacketData(oldIndex, outcome.Data));
            switch (outcome.PacketResultType)
            {
                case PacketResultType.Override when outcome.OverridePacket != null:
                    tempPacket = outcome.OverridePacket;
                    break;
                case PacketResultType.Disconnect:
                    if (packetHandler.Key == last)
                    {
                        return await _disconnectHandler(packet, session, new PacketData(oldIndex, outcome.Data));
                    }

                    break;
                case PacketResultType.Block:
                    if (packetHandler.Key == last)
                    {
                        return await _blockHandler(packet, session, new PacketData(oldIndex, outcome.Data));
                    }

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