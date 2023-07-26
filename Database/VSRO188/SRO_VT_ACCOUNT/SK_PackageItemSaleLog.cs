namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class SK_PackageItemSaleLog
{
    public int ID { get; set; }

    public int JID { get; set; }

    public int ShardID { get; set; }

    public int CharID { get; set; }

    public int PackageItemID { get; set; }

    public int Silk_Own { get; set; }

    public int Silk_Gift { get; set; }

    public int Silk_Point { get; set; }

    public int? IP { get; set; }

    public DateTime RegDate { get; set; }
}
