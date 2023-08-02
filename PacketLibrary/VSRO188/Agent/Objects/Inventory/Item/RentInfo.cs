using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class RentInfo
{
    public uint Type;
    public ushort CanDelete;
    public uint PeriodBeginTime;
    public uint PeriodEndTime;
    public ushort CanRecharge;
    public uint MeterRateTime;
    public uint PackingTime;
    
    internal static RentInfo FromPacket(Packet packet)
    {
        var result = new RentInfo();
        packet.TryRead<uint>(out result.Type);
        
        switch (result.Type)
        {
            case 1:
                packet.TryRead<ushort>(out result.CanDelete)
                    .TryRead<uint>(out result.PeriodBeginTime)
                    .TryRead<uint>(out result.PeriodEndTime);
                break;

            case 2:
                packet.TryRead<ushort>(out result.CanDelete)
                    .TryRead<ushort>(out result.CanRecharge)
                    .TryRead<uint>(out result.MeterRateTime);
                break;

            case 3:
                packet.TryRead<ushort>(out result.CanDelete)
                    .TryRead<ushort>(out result.CanRecharge)
                    .TryRead<uint>(out result.PeriodBeginTime)
                    .TryRead<uint>(out result.PeriodEndTime)
                    .TryRead<uint>(out result.PackingTime);
                break;
        }

        return result;
    }
}