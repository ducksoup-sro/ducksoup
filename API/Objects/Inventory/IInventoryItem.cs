using API.Database.SRO_VT_SHARD;
using API.Objects.Inventory.Item;

namespace API.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public interface IInventoryItem
{
    uint ItemId { get; set; }
    byte Slot { get; set; }
    IRentInfo Rental { get; set; }
    C_RefObjItem Record => ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjItem
        .First(c => c.Value.Link == ItemId).Value;
    byte OptLevel { get; set; }
    IItemAttributesInfo Attributes { get; set; }
    uint Durability { get; set; }
    List<IMagicOptionInfo> MagicOptions { get; set; }
    List<IBindingOption> BindingOptions { get; set; }
    ushort Amount { get; set; }
    InventoryItemState State { get; set; }
    IInventoryItemCosInfo Cos { get; set; }

    ITypeIdFilter GetFilter();
}