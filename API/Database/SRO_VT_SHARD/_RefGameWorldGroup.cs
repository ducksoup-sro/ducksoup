using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefGameWorldGroup
{
    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string ObjName128 { get; set; } = null!;

    public string ConfigGroupCodeName128 { get; set; } = null!;
}
