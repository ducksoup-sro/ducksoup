namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefRewardPolicyToSellScrapItem
{
    public byte Service { get; set; }

    public int Country { get; set; }

    public byte Cash { get; set; }

    public byte TypeID1 { get; set; }

    public byte TypeID2 { get; set; }

    public byte TypeID3 { get; set; }

    public byte TypeID4 { get; set; }

    public string RefItemCodeName { get; set; } = null!;

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
