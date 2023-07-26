using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _CharQuest
{
    public int CharID { get; set; }

    public int QuestID { get; set; }

    public byte Status { get; set; }

    public short AchievementCount { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public long QuestData1 { get; set; }

    public long QuestData2 { get; set; }
}
