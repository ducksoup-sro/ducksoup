using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Fellow : Cos
{
    public ushort HitRate;
    public ushort Intelligence;
    public uint MagicalAttackMax;
    public uint MagicalAttackMin;
    public ushort MagicalDefence;
    public uint PhysicalAttackMax;
    public uint PhysicalAttackMin;
    public ushort PhysicalDefence;
    public int Satiety;
    public int StoredSp;
    public ushort Strength;

    public override void Deserialize(Packet packet)
    {
        packet.TryRead(out Experience)
            .TryRead(out Level)
            .TryRead(out Satiety)
            .TryRead<ushort>(out var unk1)
            .TryRead(out StoredSp)
            .TryRead<int>(out var unk2)
            .TryRead(out Settings)
            .TryRead(out Name);

        Inventory = new InventoryItemCollection(packet);
    }
}