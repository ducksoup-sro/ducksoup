namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefTrigger
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsRepeat { get; set; }

    public string? Comment512 { get; set; }

    public int IndexNumber { get; set; }
}
