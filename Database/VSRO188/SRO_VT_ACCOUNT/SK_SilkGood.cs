namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class SK_SilkGood
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public string GoodsCode { get; set; } = null!;

    public string GoodsName { get; set; } = null!;

    public int SilkQuantity { get; set; }

    public int PointQuantity { get; set; }

    public int SilkPrice { get; set; }

    public byte Category { get; set; }

    public string CPName { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
