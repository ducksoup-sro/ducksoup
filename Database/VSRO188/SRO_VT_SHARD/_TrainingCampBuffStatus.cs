namespace Database.VSRO188.SRO_VT_SHARD;

public class _TrainingCampBuffStatus
{
    public int CampID { get; set; }

    public int RecipientCharID { get; set; }

    public byte BuffSlotIdx { get; set; }

    public int DonorCharID { get; set; }

    public DateTime StartingTime { get; set; }

    public int RemainBuffPoint { get; set; }

    public byte BuffType { get; set; }
}