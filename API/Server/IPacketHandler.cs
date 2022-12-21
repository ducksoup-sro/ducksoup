using API.Session;
using SilkroadSecurityAPI;

namespace API.Server;

// ReSharper disable once InconsistentNaming
public delegate Task<PacketResult> _PacketHandler(Packet packet, ISession session, PacketData data);

public class PacketData
{
    public object? Data { get; }
    public int PreviousPriority { get; }
    public PacketResultType PreviousResult { get; }

    public bool HasData()
    {
        return Data != null;
    }
    
    public PacketData(object data, int priority, PacketResultType previousResult)
    {
        Data = data;
        PreviousResult = previousResult;
    }
    
    public PacketData(object data, PacketResultType previousResult)
    {
        Data = data;
        PreviousResult = previousResult;
    }

    public PacketData(int previousPriority, PacketData data)
    {
        Data = data.Data;
        PreviousPriority = previousPriority;
        PreviousResult = data.PreviousResult;
    }

    public override string ToString()
    {
        return "{Data: " + Data + ",\nPriority: " + PreviousPriority + ",\nResult: " + PreviousResult + "\n}";
    }
}

public class PacketResult : IDisposable
{
    public PacketResult(PacketData data, Packet? packet, PacketResultType packetResultType = PacketResultType.Nothing)
    {
        Data = new PacketData(data, packetResultType);
        OverridePacket = null;
        if (packetResultType == PacketResultType.Override)
            OverridePacket = packet;

        PacketResultType = packetResultType;
    }
    
    public PacketResult(Packet? packet, PacketResultType packetResultType = PacketResultType.Nothing)
    {
        Data = new PacketData(null, packetResultType);
        OverridePacket = null;
        if (packetResultType == PacketResultType.Override)
            OverridePacket = packet;

        PacketResultType = packetResultType;
    }

    public PacketResult(object data, PacketResultType packetResultType = PacketResultType.Nothing)
    {
        Data = new PacketData(data, packetResultType);
        OverridePacket = null;
        PacketResultType = packetResultType;
    }
    
    public PacketResult(PacketResultType packetResultType = PacketResultType.Nothing)
    {
        Data = new PacketData(null, packetResultType);
        OverridePacket = null;
        PacketResultType = packetResultType;
    }

    public PacketData Data { get; init; }
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
    SortedDictionary<ushort, SortedDictionary<int, _PacketHandler>> _clientHandlers { get; init; }
    HashSet<ushort> _clientWhitelist { get; init; }
    SortedDictionary<ushort, SortedDictionary<int, _PacketHandler>> _serverHandlers { get; init; }

    _PacketHandler _blockHandler { get; set; }
    _PacketHandler _defaultHandler { get; set; }
    _PacketHandler _disconnectHandler { get; set; }
    
    void SetDefaultHandler(_PacketHandler handler);
    Task<PacketResult> HandleDefault(Packet packet, ISession session, PacketData data);
    void SetBlockHandler(_PacketHandler handler);
    Task<PacketResult> HandleDisconnect(Packet packet, ISession session, PacketData data);
    void SetDisconnectHandler(_PacketHandler handler);
    Task<PacketResult> HandleBlock(Packet packet, ISession session, PacketData data);
    
    void RegisterModuleHandler(ushort msgId, _PacketHandler handler);
    void RegisterModuleHandler(ushort msgId, int priority, _PacketHandler handler);
    void UnregisterModuleHandler(ushort msgId, _PacketHandler handler);
    void UnregisterAllModuleHandler(ushort msgId);
    void RegisterClientHandler(ushort msgId, _PacketHandler handler);
    void RegisterClientHandler(ushort msgId, int priority, _PacketHandler handler);
    void UnregisterClientHandler(ushort msgId, _PacketHandler handler);
    void UnregisterAllClientHandler(ushort msgId);
    
    Task<PacketResult> HandleClient(Packet packet, ISession session);
    Task<PacketResult> HandleServer(Packet packet, ISession session);
}