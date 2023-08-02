using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class BindingOption
{
    public BindingOptionType Type;
    public byte Slot;
    public uint Id;
    public uint Value;
    
    
    public static BindingOption FromPacket(Packet packet, BindingOptionType type)
    {
        packet.TryRead<byte>(out var slot)
        .TryRead<uint>(out var id)
        .TryRead<uint>(out var value);
            
        return new BindingOption
        {
            Type = type,
            Slot = slot,
            Id = id,
            Value = value
        };
    }
}