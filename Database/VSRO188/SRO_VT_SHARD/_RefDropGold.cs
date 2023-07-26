using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefDropGold
{
    public byte MonLevel { get; set; }

    public float DropProb { get; set; }

    public int GoldMin { get; set; }

    public int GoldMax { get; set; }
}
