#region

using System;
using System.Collections.Generic;
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
    public Dictionary<ushort, HashSet<_PacketHandler>> _clientHandlers { get; init; } = new();
    public HashSet<ushort> _clientWhitelist { get; init; }
    public Dictionary<ushort, HashSet<_PacketHandler>> _serverHandlers { get; init; } = new();

    public _PacketHandler _blockHandler { get; set; }
    public _PacketHandler _defaultHandler { get; set; }
    public _PacketHandler _disconnectHandler { get; set; }

    public void RegisterModuleHandler(ushort msgId, _PacketHandler handler)
    {
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null)
            _serverHandlers.Add(msgId, new HashSet<_PacketHandler>());

        _serverHandlers[msgId].Add(handler);
    }

    public void UnregisterModuleHandler(ushort msgId, _PacketHandler handler)
    {
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        _serverHandlers[msgId].RemoveWhere(m => m.Equals(handler));
    }

    public void UnregisterAllModuleHandler(ushort msgId)
    {
        if (_serverHandlers.GetValueOrDefault(msgId, null) == null) return;

        _serverHandlers[msgId].Clear();
    }

    public void RegisterClientHandler(ushort msgId, _PacketHandler handler)
    {
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null)
            _clientHandlers.Add(msgId, new HashSet<_PacketHandler>());

        _clientHandlers[msgId].Add(handler);
    }

    public void UnregisterClientHandler(ushort msgId, _PacketHandler handler)
    {
        if (_clientHandlers.GetValueOrDefault(msgId, null) == null) return;

        _clientHandlers[msgId].RemoveWhere(m => m.Equals(handler));
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

    public async Task<PacketResult> HandleDefault(Packet packet, ISession session)
    {
        return new PacketResult();
    }

    public void SetBlockHandler(_PacketHandler handler)
    {
        _blockHandler = handler;
    }

    public async Task<PacketResult> HandleDisconnect(Packet packet, ISession session)
    {
        return new PacketResult(PacketResultType.Disconnect);
    }

    public void SetDisconnectHandler(_PacketHandler handler)
    {
        _disconnectHandler = handler;
    }

    public async Task<PacketResult> HandleBlock(Packet packet, ISession session)
    {
        return new PacketResult(PacketResultType.Block);
    }

    public async Task<PacketResult> HandleClient(Packet packet, ISession session)
    {
        if (packet.Opcode == 0x9000 || packet.Opcode == 0x5000 || packet.Opcode == 0x2001)
            return await _defaultHandler(packet, session);

        // automatically blocks all packets that are not on the whitelist!
        if (_clientBlacklist.Contains(packet.Opcode))
            return await _disconnectHandler(packet, session);

        if (!_clientWhitelist.Contains(packet.Opcode))
            return await _blockHandler(packet, session);

        _clientHandlers.TryGetValue(packet.Opcode, out var handler);

        var outcome = await _defaultHandler(packet, session);
        if (handler == null) return outcome;
        var tempPacket = packet;
        foreach (var packetHandler in handler)
        {
            tempPacket = new Packet(tempPacket);
            tempPacket.ToReadOnly();

            outcome = await packetHandler.Invoke(tempPacket, session);
            switch (outcome.PacketResultType)
            {
                case PacketResultType.Override when outcome.OverridePacket != null:
                    tempPacket = outcome.OverridePacket;
                    break;
                case PacketResultType.Disconnect:
                    return await _disconnectHandler(packet, session);
                case PacketResultType.Block:
                    return await _blockHandler(packet, session);
                case PacketResultType.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return outcome;
    }

    public Task<PacketResult> HandleServer(Packet packet, ISession session)
    {
        _serverHandlers.TryGetValue(packet.Opcode, out var handler);
        var outcome = _defaultHandler(packet, session);
        if (handler == null) return outcome;
        var tempPacket = packet;
        foreach (var packetHandler in handler)
        {
            tempPacket = new Packet(tempPacket);
            tempPacket.ToReadOnly();

            outcome = packetHandler.Invoke(tempPacket, session);
            switch (outcome.Result.PacketResultType)
            {
                case PacketResultType.Override when outcome.Result.OverridePacket != null:
                    tempPacket = outcome.Result.OverridePacket;
                    break;
                case PacketResultType.Disconnect:
                    return _disconnectHandler(packet, session);
                case PacketResultType.Block:
                    return _blockHandler(packet, session);
                case PacketResultType.Nothing:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return outcome;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}