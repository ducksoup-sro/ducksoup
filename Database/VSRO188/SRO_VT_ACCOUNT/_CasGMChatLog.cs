namespace Database.VSRO188.SRO_VT_ACCOUNT;

public class _CasGMChatLog
{
    public int nSerial { get; set; }

    public string szGM { get; set; } = null!;

    public short wShardID { get; set; }

    public string szCharName { get; set; } = null!;

    public int nCasSerial { get; set; }

    public string? szGMChatLog { get; set; }

    public DateTime dWritten { get; set; }
}