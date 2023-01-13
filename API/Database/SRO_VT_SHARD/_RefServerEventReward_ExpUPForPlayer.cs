using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefServerEventReward_ExpUPForPlayer
{
    public int OwnerRewardID { get; set; }

    public int ApplyTime { get; set; }

    public byte ApplyExpRatio { get; set; }

    public byte ApplySExpRatio { get; set; }
}
