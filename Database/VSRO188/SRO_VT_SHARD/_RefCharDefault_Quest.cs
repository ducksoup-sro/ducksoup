using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefCharDefault_Quest
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public byte Race { get; set; }

    public string CodeName { get; set; } = null!;

    public byte RequiredLevel { get; set; }
}
