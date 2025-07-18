namespace Database.VSRO188.SRO_VT_SHARD;

public class _SiegeFortressBattleRecord
{
    public int FortressID { get; set; }

    public int CharID { get; set; }

    public int KillCount { get; set; }

    public int KilledCount { get; set; }

    public DateTime RankUpDate { get; set; }

    public byte CurRank { get; set; }
}