namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _ItemQuotation
{
    public int ID { get; set; }

    public int Service { get; set; }

    public int AssocNPC { get; set; }

    public int RefItemID { get; set; }

    public float BaseQuot { get; set; }

    public float Quot_LB { get; set; }

    public float Quot_UB { get; set; }

    public int BaseStockAmount { get; set; }

    public int FluctuateAmount { get; set; }

    public int CurStockAmount { get; set; }
}
