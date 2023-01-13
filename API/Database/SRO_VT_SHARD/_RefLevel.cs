using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefLevel
{
    public byte Lvl { get; set; }

    public long Exp_C { get; set; }

    public int Exp_M { get; set; }

    public int Cost_M { get; set; }

    public int Cost_ST { get; set; }

    public int GUST_Mob_Exp { get; set; }

    public int? JobExp_Trader { get; set; }

    public int? JobExp_Robber { get; set; }

    public int? JobExp_Hunter { get; set; }
}
