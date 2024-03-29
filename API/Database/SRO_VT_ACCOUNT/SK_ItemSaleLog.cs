﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SK_ItemSaleLog
{
    public int ID { get; set; }

    public int JID { get; set; }

    public int? ShardID { get; set; }

    public int? CharID { get; set; }

    public int? ItemID { get; set; }

    public int Silk_Own { get; set; }

    public int Silk_Gift { get; set; }

    public int Silk_Point { get; set; }

    public int? IP { get; set; }

    public DateTime RegDate { get; set; }
}
