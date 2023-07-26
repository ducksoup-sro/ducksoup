using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _AlliedClan
{
    public int ID { get; set; }

    public int? Ally1 { get; set; }

    public int? Ally2 { get; set; }

    public int? Ally3 { get; set; }

    public int? Ally4 { get; set; }

    public int? Ally5 { get; set; }

    public int? Ally6 { get; set; }

    public int? Ally7 { get; set; }

    public int? Ally8 { get; set; }

    public DateTime FoundationDate { get; set; }

    public int LastCrestRev { get; set; }

    public int CurCrestRev { get; set; }
}
