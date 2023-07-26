namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefShopItemStockPeriod
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public int ID { get; set; }

    public string RefShopGroupCodeName { get; set; } = null!;

    public string RefPackageItemCodeName { get; set; } = null!;

    public DateTime StockOpeningDate { get; set; }

    public DateTime StockExpireDate { get; set; }

    public byte PeriodDevice { get; set; }
}
