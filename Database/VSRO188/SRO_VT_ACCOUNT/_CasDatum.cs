namespace Database.VSRO188.SRO_VT_ACCOUNT;

public class _CasDatum
{
    public int nSerial { get; set; }

    public byte nCategory { get; set; }

    public DateTime dReportDate { get; set; }

    public short wShardID { get; set; }

    public int dwUserJID { get; set; }

    public string szCharName { get; set; } = null!;

    public string? szTgtCharName { get; set; }

    public string szMailAddress { get; set; } = null!;

    public string szStatement { get; set; } = null!;

    public byte nStatus { get; set; }

    public DateTime? dProcessDate { get; set; }

    public string? szProcessedGM { get; set; }

    public string? szMemo { get; set; }

    public string? szAnswer { get; set; }

    public byte btUserChecked { get; set; }

    public string szChatLog { get; set; } = null!;
}