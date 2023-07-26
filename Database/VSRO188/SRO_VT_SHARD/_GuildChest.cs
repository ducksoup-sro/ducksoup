using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _GuildChest
{
    public int GuildID { get; set; }

    public byte Slot { get; set; }

    public long? ItemID { get; set; }
}
