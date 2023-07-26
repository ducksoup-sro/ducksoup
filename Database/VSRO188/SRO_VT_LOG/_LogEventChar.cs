namespace Database.VSRO188.SRO_VT_LOG;

public partial class _LogEventChar
{
    public int CharID { get; set; }

    public DateTime EventTime { get; set; }

    public byte EventID { get; set; }

    public int Data1 { get; set; }

    public int Data2 { get; set; }

    public string? EventPos { get; set; }

    public string? strDesc { get; set; }
}
