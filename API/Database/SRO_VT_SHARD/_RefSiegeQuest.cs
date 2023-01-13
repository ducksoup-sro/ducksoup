using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefSiegeQuest
{
    public byte Service { get; set; }

    public int QuestID { get; set; }

    public string QuestName { get; set; } = null!;

    public byte QuestType { get; set; }

    public byte RewardConditionTargetCount { get; set; }

    public byte IsAccumulation { get; set; }
}
