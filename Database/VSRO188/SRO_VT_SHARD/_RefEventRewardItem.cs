namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefEventRewardItem
{
    public byte Service { get; set; }

    public int EventID { get; set; }

    public string EventCodeName { get; set; } = null!;

    public string ItemCodeName { get; set; } = null!;

    public int PayCount { get; set; }

    public float AchieveRatio { get; set; }

    public string RentItemCodeName { get; set; } = null!;

    public int Param1 { get; set; }

    public string Param1_Desc { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc { get; set; } = null!;
}
