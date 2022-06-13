using API.Session;
using SilkroadSecurityAPI;

namespace API.Server;

// ReSharper disable once InconsistentNaming
public delegate Task<PacketResult> _PacketHandler(Packet packet, ISession session);

public class PacketResult : IDisposable
{
    public PacketResult(Packet? packet, PacketResultType packetResultType = PacketResultType.Nothing)
    {
        OverridePacket = null;
        if (packetResultType == PacketResultType.Override)
            OverridePacket = packet;

        PacketResultType = packetResultType;
    }

    public PacketResult(PacketResultType packetResultType = PacketResultType.Nothing)
    {
        OverridePacket = null;
        PacketResultType = packetResultType;
    }

    public Packet? OverridePacket { get; init; }
    public PacketResultType PacketResultType { get; init; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
public interface IPacketHandler : IDisposable
{
    HashSet<ushort> _clientBlacklist { get; init; }
    Dictionary<ushort, HashSet<_PacketHandler>> _clientHandlers { get; init; }
    HashSet<ushort> _clientWhitelist { get; init; }
    Dictionary<ushort, HashSet<_PacketHandler>> _serverHandlers { get; init; }

    _PacketHandler _blockHandler { get; set; }
    _PacketHandler _defaultHandler { get; set; }
    _PacketHandler _disconnectHandler { get; set; }
    
    void SetDefaultHandler(_PacketHandler handler);
    Task<PacketResult> HandleDefault(Packet packet, ISession session);
    void SetBlockHandler(_PacketHandler handler);
    Task<PacketResult> HandleDisconnect(Packet packet, ISession session);
    void SetDisconnectHandler(_PacketHandler handler);
    Task<PacketResult> HandleBlock(Packet packet, ISession session);
    
    void RegisterModuleHandler(ushort msgId, _PacketHandler handler);
    void UnregisterModuleHandler(ushort msgId, _PacketHandler handler);
    void UnregisterAllModuleHandler(ushort msgId);
    void RegisterClientHandler(ushort msgId, _PacketHandler handler);
    void UnregisterClientHandler(ushort msgId, _PacketHandler handler);
    void UnregisterAllClientHandler(ushort msgId);
    
    Task<PacketResult> HandleClient(Packet packet, ISession session);
    Task<PacketResult> HandleServer(Packet packet, ISession session);
}