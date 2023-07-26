namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class __TrijobRanking__
{
    public int ShardID { get; set; }

    public byte TrijobType { get; set; }

    public byte RankType { get; set; }

    public byte Rank { get; set; }

    public string NickName { get; set; } = null!;

    public byte JobLevel { get; set; }

    public int JobData { get; set; }

    public byte IsNewEntry { get; set; }

    public short RankDelta { get; set; }

    public byte Country { get; set; }
}
