namespace API.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public interface IInventoryItemCosInfo
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public IRentInfo Rental { get; set; }
}