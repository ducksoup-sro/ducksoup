namespace Database.VSRO188.SRO_VT_SHARD;

public class _ShopItemStockQuantity
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public string RefShopGroupCodeName { get; set; } = null!;

    public string RefPackageItemCodeName { get; set; } = null!;

    public short ConstStockQuantity { get; set; }

    public short StockQuantity { get; set; }
}