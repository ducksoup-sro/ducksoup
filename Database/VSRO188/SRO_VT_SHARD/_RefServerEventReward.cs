using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefServerEventReward
{
    public byte Service { get; set; }

    public int RewardID { get; set; }

    public int OwnerServerEventID { get; set; }

    public int RefRewardID { get; set; }

    public byte Quantity { get; set; }

    public byte RewardClass { get; set; }

    public byte MasterReward { get; set; }
}
