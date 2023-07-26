using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefAbilityByItemOptLevel
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public int RefItemID { get; set; }

    public byte ItemOptLevel { get; set; }
}
