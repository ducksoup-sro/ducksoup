using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefInstance_World_Start_Po
{
    public int WorldID { get; set; }

    public short RegionID { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public int PosZ { get; set; }

    public int? Param { get; set; }
}
