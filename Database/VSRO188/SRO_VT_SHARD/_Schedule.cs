namespace Database.VSRO188.SRO_VT_SHARD;

public class _Schedule
{
    public int ScheduleIdx { get; set; }

    public int ScheduleDefineIdx { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int MainInterval_Type { get; set; }

    public int MainInterval_TypeDate { get; set; }

    public byte? SubInterval_DayOfWeek { get; set; }

    public byte? SubInterval_Days { get; set; }

    public byte? SubInterval_Weeks { get; set; }

    public byte? SubInterval_Months { get; set; }

    public byte? SubInterval_StartTimeHour { get; set; }

    public byte? SubInterval_StartTimeMinute { get; set; }

    public byte? SubInterval_StartTimeSecond { get; set; }

    public int? SubInterval_DurationSecond { get; set; }

    public int? SubInterval_RepititionTerm { get; set; }

    public int? SubInterval_MaintainTime { get; set; }

    public string? Param { get; set; }

    public string? Description { get; set; }
}