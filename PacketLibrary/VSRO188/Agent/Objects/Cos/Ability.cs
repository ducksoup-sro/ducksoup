using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Ability : Cos
{
    public override void Deserialize(Packet packet)
    {
        packet.TryRead(out Settings)
            .TryRead(out Name);
        Inventory = new InventoryItemCollection(packet);
        packet.TryRead(out OwnerUniqueId)
            .TryRead<byte>(out var inventorySlot);
    }
}