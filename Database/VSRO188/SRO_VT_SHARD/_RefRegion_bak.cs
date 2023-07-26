using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefRegion_bak
{
    public short wRegionID { get; set; }

    public byte X { get; set; }

    public byte Z { get; set; }

    public string ContinentName { get; set; } = null!;

    public string AreaName { get; set; } = null!;

    public byte IsBattleField { get; set; }

    public int Climate { get; set; }

    public int MaxCapacity { get; set; }

    public int AssocObjID { get; set; }

    public int AssocServer { get; set; }

    public string AssocFile256 { get; set; } = null!;

    public int? LinkedRegion_1 { get; set; }

    public int? LinkedRegion_2 { get; set; }

    public int? LinkedRegion_3 { get; set; }

    public int? LinkedRegion_4 { get; set; }

    public int? LinkedRegion_5 { get; set; }

    public int? LinkedRegion_6 { get; set; }

    public int? LinkedRegion_7 { get; set; }

    public int? LinkedRegion_8 { get; set; }

    public int? LinkedRegion_9 { get; set; }

    public int? LinkedRegion_10 { get; set; }
}
