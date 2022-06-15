using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class Shard
{
    public ushort Id { get; set; }
    public string Name { get; set; }
    public ushort OnlineCount { get; set; }
    public ushort Capacity { get; set; }
    public bool IsOperating { get; set; }
    public byte FarmId { get; set; }

    public Shard(Packet packet)
    {
        Id = packet.ReadUInt16(); // 2 ushort shard.ID
        // 2 ushort shard.Name.Length
        //     * string shard.Name
        Name = packet.ReadAscii();
        OnlineCount = packet.ReadUInt16(); // 2 ushort shard.OnlineCount
        Capacity = packet.ReadUInt16(); // 2 ushort shard.Capacity
        IsOperating = packet.ReadBool(); // 1 bool shard.IsOperating
        FarmId = packet.ReadUInt8(); // 1 byte shard.FarmID
    }

    public Shard(ushort id, string name, ushort onlineCount, ushort capacity, bool isOperating, byte farmId)
    {
        Id = id;
        Name = name;
        OnlineCount = onlineCount;
        Capacity = capacity;
        IsOperating = isOperating;
        FarmId = farmId;
    }

    public Packet build(Packet packet)
    {
        packet.WriteUInt16(Id);
        packet.WriteAscii(Name);
        packet.WriteUInt16(OnlineCount);
        packet.WriteUInt16(Capacity);
        packet.WriteBool(IsOperating);
        packet.WriteUInt8(FarmId);

        return packet;
    }
}