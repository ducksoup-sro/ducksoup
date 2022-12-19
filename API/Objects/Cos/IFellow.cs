namespace API.Objects.Cos;

public interface IFellow : ICos
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

    // public override void Deserialize(Packet packet)
    // {
    //     Experience = packet.ReadLong();
    //     Level = packet.ReadByte();
    //     Satiety = packet.ReadInt();
    //     var unknown1 = packet.ReadUShort();
    //     StoredSp = packet.ReadInt();
    //     var unknown2 = packet.ReadInt();
    //     Settings = packet.ReadInt();
    //     Name = packet.ReadString();
    //     Inventory = new InventoryItemCollection(packet);
    // }
}