namespace API.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/s
public interface IBindingOption
{
    public BindingOptionType Type { get; set; }
    public byte Slot { get; set; }
    public uint Id { get; set; }
    public uint Value { get; set; }
}