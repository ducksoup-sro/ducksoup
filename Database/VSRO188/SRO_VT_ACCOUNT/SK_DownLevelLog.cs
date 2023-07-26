namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class SK_DownLevelLog
{
    public int id { get; set; }

    public int? JID { get; set; }

    public string? struserid { get; set; }

    public string? charname { get; set; }

    public string? package { get; set; }

    public string? newlevel { get; set; }

    public string? server { get; set; }

    public DateTime? timedown { get; set; }
}
