namespace Database.VSRO188.SRO_VT_LOG;

public partial class _LogEventSiegeFortress
{
    public int ID { get; set; }

    public int FortressID { get; set; }

    public DateTime EventTime { get; set; }

    public byte EventID { get; set; }

    public int CharID { get; set; }

    public int Data1 { get; set; }

    public int Data2 { get; set; }

    public string? strDesc { get; set; }
}
