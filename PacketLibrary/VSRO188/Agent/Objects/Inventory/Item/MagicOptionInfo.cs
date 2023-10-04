using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class MagicOptionInfo
{
    public uint Id;
    public uint Value;

    public static MagicOptionInfo FromPacket(Packet packet)
    {
        packet.TryRead<uint>(out var id)
            .TryRead<uint>(out var value);

        return new MagicOptionInfo
        {
            Id = id,
            Value = value
        };
    }
}