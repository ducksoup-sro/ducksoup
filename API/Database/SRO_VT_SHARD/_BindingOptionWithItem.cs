using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _BindingOptionWithItem
{
    public long nItemDBID { get; set; }

    public byte bOptType { get; set; }

    public byte nSlot { get; set; }

    public int nOptID { get; set; }

    public byte nOptLvl { get; set; }

    public int nOptValue { get; set; }

    public int? nParam1 { get; set; }

    public int? nParam2 { get; set; }
}
