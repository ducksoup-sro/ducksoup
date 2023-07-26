namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class _ModuleVersionFile
{
    public int nID { get; set; }

    public int nVersion { get; set; }

    public byte nDivisionID { get; set; }

    public byte nContentID { get; set; }

    public byte nModuleID { get; set; }

    public string szFilename { get; set; } = null!;

    public string szPath { get; set; } = null!;

    public int nFileSize { get; set; }

    public byte nFileType { get; set; }

    public int nFileTypeVersion { get; set; }

    public byte nToBePacked { get; set; }

    public DateTime timeModified { get; set; }

    public byte nValid { get; set; }
}
