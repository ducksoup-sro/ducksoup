using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefShopTabGroup
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string StrID128_Group { get; set; } = null!;
}
