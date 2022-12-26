using API.Objects.Inventory;
using API.Objects.Spawn;

namespace API.Objects.Cos;

public interface ICos : ISpawnedEntity
{
    public uint OwnerUniqueId { get; set; }
    public string Name { get; set; }
    public byte Level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Settings { get; set; }
    public bool HasHealth => Health > 0;
    public long Experience { get; set; }
    public BadStatus BadEffect { get; set; }
    public IInventoryItemCollection Inventory { get; set; }

}