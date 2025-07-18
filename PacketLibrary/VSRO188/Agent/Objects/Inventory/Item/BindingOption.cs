using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class BindingOption
{
    public uint Id;
    public byte Slot;
    public BindingOptionType Type;
    public uint Value;


    public static BindingOption FromPacket(Packet packet, BindingOptionType type)
    {
        packet.TryRead<byte>(out byte slot)
            .TryRead<uint>(out uint id)
            .TryRead<uint>(out uint value);

        return new BindingOption
        {
            Type = type,
            Slot = slot,
            Id = id,
            Value = value
        };
    }
}