using API;
using API.Objects.Inventory.Item;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class BindingOption : IBindingOption
{
    public BindingOptionType Type { get; set; }
    public byte Slot { get; set; }
    public uint Id { get; set; }
    public uint Value { get; set; }
    
    
    public static IBindingOption FromPacket(Packet packet, BindingOptionType type)
    {
        return new BindingOption
        {
            Type = type,
            Slot = packet.ReadUInt8(),
            Id = packet.ReadUInt32(),
            Value = packet.ReadUInt32()
        };
    }
}