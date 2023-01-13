using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _OpenMarket
{
    public int JID { get; set; }

    public int PersnalID { get; set; }

    public string CharName16 { get; set; } = null!;

    public byte Status { get; set; }

    public int RefItemID { get; set; }

    public int TidGroupID { get; set; }

    public int ItemClass { get; set; }

    public long ItemID { get; set; }

    public int SellCnt { get; set; }

    public DateTime RegDate { get; set; }

    public DateTime EndDate { get; set; }

    public long Price { get; set; }

    public long Deposit { get; set; }

    public long SellFee { get; set; }

    public int UseCash { get; set; }

    public long Serial64 { get; set; }
}
