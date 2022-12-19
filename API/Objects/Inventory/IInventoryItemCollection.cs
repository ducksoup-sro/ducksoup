using SilkroadSecurityAPI;

namespace API.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public interface IInventoryItemCollection : ICollection<IInventoryItem>
{
    void Deserialize(Packet packet);
}