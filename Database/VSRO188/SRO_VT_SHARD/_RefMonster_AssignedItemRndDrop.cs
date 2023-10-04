namespace Database.VSRO188.SRO_VT_SHARD;

public class _RefMonster_AssignedItemRndDrop
{
    public byte Service { get; set; }

    public int RefMonsterID { get; set; }

    public int RefItemGroupID { get; set; }

    public string ItemGroupCodeName128 { get; set; } = null!;

    public byte Overlap { get; set; }

    public byte DropAmountMin { get; set; }

    public byte DropAmountMax { get; set; }

    public float DropRatio { get; set; }

    public int param1 { get; set; }

    public int param2 { get; set; }
}