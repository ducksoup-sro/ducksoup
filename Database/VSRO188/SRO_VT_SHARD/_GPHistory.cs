namespace Database.VSRO188.SRO_VT_SHARD;

public class _GPHistory
{
    public int ID { get; set; }

    public int GuildID { get; set; }

    public DateTime? UsedTime { get; set; }

    public string CharName { get; set; } = null!;

    public int UsedGP { get; set; }

    public byte Reason { get; set; }
}