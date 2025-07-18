namespace Database.VSRO188.SRO_VT_SHARD;

public class _RefOptionalTeleport
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string ObjName128 { get; set; } = null!;

    public string ZoneName128 { get; set; } = null!;

    public short RegionID { get; set; }

    public short Pos_X { get; set; }

    public short Pos_Y { get; set; }

    public short Pos_Z { get; set; }

    public short WorldID { get; set; }

    public int RegionIDGroup { get; set; }

    public byte MapPoint { get; set; }

    public short LevelMin { get; set; }

    public short LevelMax { get; set; }

    public int? Param1 { get; set; }

    public string? Param1_Desc_128 { get; set; }

    public int? Param2 { get; set; }

    public string? Param2_Desc_128 { get; set; }

    public int? Param3 { get; set; }

    public string? Param3_Desc_128 { get; set; }
}