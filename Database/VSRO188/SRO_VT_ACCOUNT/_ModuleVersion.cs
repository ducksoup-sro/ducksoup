namespace Database.VSRO188.SRO_VT_ACCOUNT;

public class _ModuleVersion
{
    public int nID { get; set; }

    public byte nDivisionID { get; set; }

    public byte nContentID { get; set; }

    public byte nModuleID { get; set; }

    public int nVersion { get; set; }

    public string szVersion { get; set; } = null!;

    public string szDesc { get; set; } = null!;

    public byte nValid { get; set; }
}