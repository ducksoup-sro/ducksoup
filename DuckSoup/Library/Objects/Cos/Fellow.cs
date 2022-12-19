using API.Objects.Cos;
using DuckSoup.Library.Objects.Inventory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Fellow : Cos, IFellow
{
    public ushort Strength { get; set; }
    public ushort Intelligence { get; set; }
    public uint PhysicalAttackMin { get; set; }
    public uint PhysicalAttackMax { get; set; }
    public uint MagicalAttackMin { get; set; }
    public uint MagicalAttackMax { get; set; }
    public ushort PhysicalDefence { get; set; }
    public ushort MagicalDefence { get; set; }
    public ushort HitRate { get; set; }
    public int Satiety { get; set; }
    public int StoredSp { get; set; }
    
    public override void Deserialize(Packet packet)
    {
        Experience = packet.ReadInt64();
        Level = packet.ReadUInt8();
        Satiety = packet.ReadInt32();
        var unknown1 = packet.ReadUInt16();
        StoredSp = packet.ReadInt32();
        var unknown2 = packet.ReadInt32();
        Settings = packet.ReadInt32();
        Name = packet.ReadAscii();
        Inventory = new InventoryItemCollection(packet);
    }
}