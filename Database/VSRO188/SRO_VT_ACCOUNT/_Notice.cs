namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class _Notice
{
    public int ID { get; set; }

    public byte ContentID { get; set; }

    public string Subject { get; set; } = null!;

    public string Article { get; set; } = null!;

    public DateTime EditDate { get; set; }
}
