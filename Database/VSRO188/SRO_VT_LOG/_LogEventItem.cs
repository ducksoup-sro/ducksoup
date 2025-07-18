namespace Database.VSRO188.SRO_VT_LOG;

public class _LogEventItem
{
    public DateTime EventTime { get; set; }

    public int CharID { get; set; }

    public int ItemRefID { get; set; }

    public int dwData { get; set; }

    public byte TargetStorage { get; set; }

    public byte Operation { get; set; }

    public byte Slot_From { get; set; }

    public byte Slot_To { get; set; }

    public string? EventPos { get; set; }

    public string? strDesc { get; set; }

    public long Serial64 { get; set; }

    public long? Gold { get; set; }
}