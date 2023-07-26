using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _BlockedWhisperer
{
    public int OwnerID { get; set; }

    public string TargetName { get; set; } = null!;
}
