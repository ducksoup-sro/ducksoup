namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefSiegeFortressBattleRank
{
    public byte Service { get; set; }

    public byte RankLvl { get; set; }

    public string RankName { get; set; } = null!;

    public int ReqPKCount { get; set; }

    public int BindedSkillID { get; set; }

    public string CrestPath128 { get; set; } = null!;
}
