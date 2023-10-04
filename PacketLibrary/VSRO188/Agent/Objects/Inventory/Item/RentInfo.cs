using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public class RentInfo
{
    public ushort CanDelete;
    public ushort CanRecharge;
    public uint MeterRateTime;
    public uint PackingTime;
    public uint PeriodBeginTime;
    public uint PeriodEndTime;
    public uint Type;

    internal static RentInfo FromPacket(Packet packet)
    {
        var result = new RentInfo();
        packet.TryRead(out result.Type);

        switch (result.Type)
        {
            case 1:
                packet.TryRead(out result.CanDelete)
                    .TryRead(out result.PeriodBeginTime)
                    .TryRead(out result.PeriodEndTime);
                break;

            case 2:
                packet.TryRead(out result.CanDelete)
                    .TryRead(out result.CanRecharge)
                    .TryRead(out result.MeterRateTime);
                break;

            case 3:
                packet.TryRead(out result.CanDelete)
                    .TryRead(out result.CanRecharge)
                    .TryRead(out result.PeriodBeginTime)
                    .TryRead(out result.PeriodEndTime)
                    .TryRead(out result.PackingTime);
                break;
        }

        return result;
    }
}