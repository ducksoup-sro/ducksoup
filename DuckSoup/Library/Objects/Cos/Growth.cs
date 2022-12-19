using API.Objects.Cos;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Growth : Cos, IGrowth
{
    public ushort CurrentHungerPoints { get; set; }


    public override void Deserialize(Packet packet)
    {
        Experience = packet.ReadInt64();
        Level = packet.ReadUInt8();
        CurrentHungerPoints = packet.ReadUInt16();
        Settings = packet.ReadInt32();
        Name = packet.ReadAscii();
        packet.ReadUInt8(); // ??
        OwnerUniqueId = packet.ReadUInt32();
        packet.ReadUInt8(); // inventorySlot
    }
}