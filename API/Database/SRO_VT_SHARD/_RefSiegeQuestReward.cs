using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefSiegeQuestReward
{
    public byte Service { get; set; }

    public int QuestID { get; set; }

    public byte RewardType { get; set; }

    public int RewardRefID { get; set; }

    public int RewardValue { get; set; }
}
