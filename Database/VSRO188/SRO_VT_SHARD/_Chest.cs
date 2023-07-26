using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _Chest
{
    public int UserJID { get; set; }

    public byte Slot { get; set; }

    public long? ItemID { get; set; }
}
