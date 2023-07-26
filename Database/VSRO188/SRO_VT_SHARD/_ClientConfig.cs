using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _ClientConfig
{
    public int CharID { get; set; }

    public byte ConfigType { get; set; }

    public byte SlotSeq { get; set; }

    public byte SlotType { get; set; }

    public int Data { get; set; }
}
