using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _TrainingCampHonorRank
{
    public int Ranking { get; set; }

    public int? CampID { get; set; }

    public byte? Rank { get; set; }
}
