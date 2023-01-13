using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefScheduleDefine
{
    public int ScheduleDefineIdx { get; set; }

    public string ScheduleName { get; set; } = null!;

    public string? Description { get; set; }
}
