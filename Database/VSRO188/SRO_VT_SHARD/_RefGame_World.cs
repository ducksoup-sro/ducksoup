using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefGame_World
{
    public int ID { get; set; }

    public string WorldCodeName128 { get; set; } = null!;

    public byte Type { get; set; }

    public short WorldMaxCount { get; set; }

    public short WorldMaxUserCount { get; set; }

    public byte WorldEntryType { get; set; }

    public byte WorldEntranceType { get; set; }

    public byte WorldLeaveType { get; set; }

    public int WorldDurationTime { get; set; }

    public int WorldEmptyRemainTime { get; set; }

    public string ConfigGroupCodeName128 { get; set; } = null!;
}
