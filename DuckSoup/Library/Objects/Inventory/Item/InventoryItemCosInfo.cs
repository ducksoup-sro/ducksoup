using API.Objects.Inventory.Item;

namespace DuckSoup.Library.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class InventoryItemCosInfo : IInventoryItemCosInfo
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public IRentInfo Rental { get; set; }
}