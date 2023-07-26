using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefShopGroup
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public short ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string RefNPCCodeName { get; set; } = null!;

    public int Param1 { get; set; }

    public string Param1_Desc128 { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc128 { get; set; } = null!;

    public int Param3 { get; set; }

    public string Param3_Desc128 { get; set; } = null!;

    public int Param4 { get; set; }

    public string Param4_Desc128 { get; set; } = null!;
}
