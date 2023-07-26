namespace Database.VSRO188.SRO_VT_LOG;

public partial class _LogSchedule
{
    public int ID { get; set; }

    public string ServerType { get; set; } = null!;

    public int ServerBodyID { get; set; }

    public string ScheduleDefine { get; set; } = null!;

    public int ScheduleIdx { get; set; }

    public string Type { get; set; } = null!;

    public DateTime OccureTime { get; set; }
}
