namespace API.Objects.Inventory.Item;

// https://github.com/SDClowen/RSBot/
public interface IRentInfo
{
    uint Type { get; set; }
    ushort CanDelete { get; set; }
    ulong PeriodBeginTime { get; set; }
    ulong PeriodEndTime { get; set; }
    ushort CanRecharge { get; set; }
    ulong MeterRateTime { get; set; }
    ulong PackingTime { get; set; }
}