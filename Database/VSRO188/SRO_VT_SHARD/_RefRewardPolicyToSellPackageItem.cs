using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefRewardPolicyToSellPackageItem
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public string RefPackageItemCodeName { get; set; } = null!;

    public byte AcceptOrReject { get; set; }

    public int FourCC { get; set; }

    public int Param1 { get; set; }

    public string Param1_Desc128 { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc128 { get; set; } = null!;

    public int Param3 { get; set; }

    public string Param3_Desc128 { get; set; } = null!;

    public int Param4 { get; set; }

    public string Param4_Desc128 { get; set; } = null!;
}
