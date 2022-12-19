using API.Objects.Inventory.Item;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class MagicOptionInfo : IMagicOptionInfo
{
    public uint Id { get; set; }
    public uint Value { get; set; }
    
    public static IMagicOptionInfo FromPacket(Packet packet)
    {
        return new MagicOptionInfo
        {
            Id = packet.ReadUInt32(),
            Value = packet.ReadUInt32()
        };
    }
}