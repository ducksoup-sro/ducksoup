namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefTriggerCondition
{
    public int Service { get; set; }

    public int ID { get; set; }

    public int RefTriggerCommonID { get; set; }

    public string OnTrue { get; set; } = null!;

    public string OnFalse { get; set; } = null!;

    public short Sequence { get; set; }

    public string ParamGroupCodeName128 { get; set; } = null!;
}
