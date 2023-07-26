namespace Database.VSRO188.SRO_VT_SHARD;

public partial class Tab_RefNest
{
    public int dwNestID { get; set; }

    public int dwHiveID { get; set; }

    public int dwTacticsID { get; set; }

    public short nRegionDBID { get; set; }

    public float? fLocalPosX { get; set; }

    public float? fLocalPosY { get; set; }

    public float? fLocalPosZ { get; set; }

    public short? wInitialDir { get; set; }

    public int? nRadius { get; set; }

    public int? nGenerateRadius { get; set; }

    public int? nChampionGenPercentage { get; set; }

    public int? dwDelayTimeMin { get; set; }

    public int? dwDelayTimeMax { get; set; }

    public int dwMaxTotalCount { get; set; }

    public byte? btFlag { get; set; }

    public byte btRespawn { get; set; }

    public byte btType { get; set; }
}
