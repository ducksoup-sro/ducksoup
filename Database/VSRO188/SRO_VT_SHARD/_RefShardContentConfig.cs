using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefShardContentConfig
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string CodeDesc128 { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? Type { get; set; }
}
