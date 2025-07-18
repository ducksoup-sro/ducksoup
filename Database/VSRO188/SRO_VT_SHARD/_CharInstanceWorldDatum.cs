namespace Database.VSRO188.SRO_VT_SHARD;

public class _CharInstanceWorldDatum
{
    public int CharID { get; set; }

    public int DungeonKeyID { get; set; }

    public int WorldID { get; set; }

    public int LayerID { get; set; }

    public DateTime OpenedTime { get; set; }

    public short RegionID { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public int PosZ { get; set; }

    public byte IsActivated { get; set; }

    public int EnterCount { get; set; }

    public DateTime LastEnterTime { get; set; }
}