using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefDropItemGroup
{
    public byte Service { get; set; }

    public int RefItemGroupID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public int RefItemID { get; set; }

    public float SelectRatio { get; set; }

    public int RefMagicGroupID { get; set; }
}
