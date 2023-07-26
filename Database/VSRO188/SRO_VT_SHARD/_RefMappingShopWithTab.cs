using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefMappingShopWithTab
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public string RefShopCodeName { get; set; } = null!;

    public string RefTabGroupCodeName { get; set; } = null!;
}
