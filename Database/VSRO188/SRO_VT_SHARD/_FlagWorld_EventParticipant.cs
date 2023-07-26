using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _FlagWorld_EventParticipant
{
    public int JID { get; set; }

    public DateTime LatestAttempt { get; set; }

    public int Count { get; set; }
}
