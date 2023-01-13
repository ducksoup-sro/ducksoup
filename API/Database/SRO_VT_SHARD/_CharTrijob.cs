using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _CharTrijob
{
    public int CharID { get; set; }

    public byte JobType { get; set; }

    public byte Level { get; set; }

    public int Exp { get; set; }

    public int Contribution { get; set; }

    public int Reward { get; set; }
}
