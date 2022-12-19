using API.Session;
using DuckSoup.Library.Objects.Inventory;
using SilkroadSecurityAPI;

namespace API.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Ability : DuckSoup.Library.Objects.Cos.Cos, IAbility
{
    public override void Deserialize(Packet packet)
    {
        Settings = packet.ReadInt32();
        Name = packet.ReadAscii();
        Inventory = new InventoryItemCollection(packet);
        OwnerUniqueId = packet.ReadUInt32();
        packet.ReadUInt8(); // inventorySlot
    }
}