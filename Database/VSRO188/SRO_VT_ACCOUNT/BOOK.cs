namespace Database.VSRO188.SRO_VT_ACCOUNT;

public class BOOK
{
    public int id { get; set; }

    public string title { get; set; } = null!;

    public DateTime pubdate { get; set; }

    public string synopsis { get; set; } = null!;

    public bool inprint { get; set; }

    public int salesCount { get; set; }
}