using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class Shard
{
    public readonly ushort Capacity;
    public readonly byte FarmId;
    public readonly ushort Id;
    public readonly bool IsOperating;
    public readonly string Name;
    public readonly ushort OnlineCount;

    public Shard(Packet packet)
    {
        packet.TryRead(out Id)
            .TryRead(out Name)
            .TryRead(out OnlineCount)
            .TryRead(out Capacity)
            .TryRead(out IsOperating)
            .TryRead(out FarmId);

        // Id = packet.ReadUInt16(); // 2 ushort shard.ID
        // // 2 ushort shard.Name.Length
        // //     * string shard.Name
        // Name = packet.ReadAscii();
        // OnlineCount = packet.ReadUInt16(); // 2 ushort shard.OnlineCount
        // Capacity = packet.ReadUInt16(); // 2 ushort shard.Capacity
        // IsOperating = packet.ReadBool(); // 1 bool shard.IsOperating
        // FarmId = packet.ReadUInt8(); // 1 byte shard.FarmID
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

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Id)
            .TryWrite(Name)
            .TryWrite(OnlineCount)
            .TryWrite(Capacity)
            .TryWrite(IsOperating)
            .TryWrite(FarmId);

        // packet.WriteUInt16(Id);
        // packet.WriteAscii(Name);
        // packet.WriteUInt16(OnlineCount);
        // packet.WriteUInt16(Capacity);
        // packet.WriteBool(IsOperating);
        // packet.WriteUInt8(FarmId);
        return packet;
    }
}