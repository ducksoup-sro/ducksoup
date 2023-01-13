using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _ServerEvent
{
    public int ID { get; set; }

    public int CompletionValue { get; set; }

    public int AchievementCondition { get; set; }

    public int ProgressCount { get; set; }
}
