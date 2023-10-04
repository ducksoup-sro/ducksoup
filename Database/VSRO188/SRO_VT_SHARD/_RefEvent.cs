namespace Database.VSRO188.SRO_VT_SHARD;

public class _RefEvent
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public string CodeName { get; set; } = null!;

    public string DescName { get; set; } = null!;

    public string? ScheduleName { get; set; }

    public int ScheduleCount { get; set; }
}