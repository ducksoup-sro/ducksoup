using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Fellow : Cos
{
    public ushort Strength;
    public ushort Intelligence;
    public uint PhysicalAttackMin;
    public uint PhysicalAttackMax;
    public uint MagicalAttackMin;
    public uint MagicalAttackMax;
    public ushort PhysicalDefence;
    public ushort MagicalDefence;
    public ushort HitRate;
    public int Satiety;
    public int StoredSp;
    
    public override void Deserialize(Packet packet)
    {
        packet.TryRead<long>(out Experience)
            .TryRead<byte>(out Level)
            .TryRead<int>(out Satiety)
            .TryRead<ushort>(out var unk1)
            .TryRead<int>(out StoredSp)
            .TryRead<int>(out var unk2)
            .TryRead<int>(out Settings)
            .TryRead(out Name);

        Inventory = new InventoryItemCollection(packet);
    }
}