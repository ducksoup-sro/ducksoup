using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _InvCO
{
    public int COSID { get; set; }

    public byte Slot { get; set; }

    public long? ItemID { get; set; }
}
