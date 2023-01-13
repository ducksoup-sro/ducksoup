using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _TrainingCamp
{
    public int ID { get; set; }

    public DateTime CreationDate { get; set; }

    public byte Rank { get; set; }

    public int GraduateCount { get; set; }

    public int EvaluationPoint { get; set; }

    public DateTime LatestEvaluationDate { get; set; }

    public string? CommentTitle { get; set; }

    public string? Comment { get; set; }
}
