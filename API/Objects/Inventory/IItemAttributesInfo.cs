namespace API.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public interface IItemAttributesInfo : IEquatable<IItemAttributesInfo>
{
    ulong Variance { get; }
}