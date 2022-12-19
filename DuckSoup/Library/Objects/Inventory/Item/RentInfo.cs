using API.Objects.Inventory.Item;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class RentInfo : IRentInfo
{
    public uint Type { get; set; }
    public ushort CanDelete { get; set; }
    public ulong PeriodBeginTime { get; set; }
    public ulong PeriodEndTime { get; set; }
    public ushort CanRecharge { get; set; }
    public ulong MeterRateTime { get; set; }
    public ulong PackingTime { get; set; }
    
    internal static IRentInfo FromPacket(Packet packet)
    {
        var result = new RentInfo
        {
            Type = packet.ReadUInt32()
        };

        switch (result.Type)
        {
            case 1:
                result.CanDelete = packet.ReadUInt16();
                result.PeriodBeginTime = packet.ReadUInt32();
                result.PeriodEndTime = packet.ReadUInt32();
                break;

            case 2:
                result.CanDelete = packet.ReadUInt16();
                result.CanRecharge = packet.ReadUInt16();
                result.MeterRateTime = packet.ReadUInt32();
                break;

            case 3:
                result.CanDelete = packet.ReadUInt16();
                result.CanRecharge = packet.ReadUInt16();
                result.PeriodBeginTime = packet.ReadUInt32();
                result.PeriodEndTime = packet.ReadUInt32();
                result.PackingTime = packet.ReadUInt32();
                break;
        }

        return result;
    }
}