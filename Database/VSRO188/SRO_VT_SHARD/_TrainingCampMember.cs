namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _TrainingCampMember
{
    public int CampID { get; set; }

    public int CharID { get; set; }

    public int RefObjID { get; set; }

    public string CharName { get; set; } = null!;

    public DateTime JoinDate { get; set; }

    public byte MemberClass { get; set; }

    public byte CharJoinedLevel { get; set; }

    public byte CharCurLevel { get; set; }

    public byte CharMaxLevel { get; set; }

    public int HonorPoint { get; set; }
}
