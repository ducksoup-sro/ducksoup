using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefTriggerCommon
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string ObjName128 { get; set; } = null!;

    public short TID1 { get; set; }

    public short TID2 { get; set; }

    public short TID3 { get; set; }

    public short TID4 { get; set; }
}
