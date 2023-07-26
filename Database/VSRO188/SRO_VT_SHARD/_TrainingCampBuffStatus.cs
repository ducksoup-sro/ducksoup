using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _TrainingCampBuffStatus
{
    public int CampID { get; set; }

    public int RecipientCharID { get; set; }

    public byte BuffSlotIdx { get; set; }

    public int DonorCharID { get; set; }

    public DateTime StartingTime { get; set; }

    public int RemainBuffPoint { get; set; }

    public byte BuffType { get; set; }
}
