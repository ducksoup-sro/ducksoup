using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _SiegeFortressItemForge
{
    public int FortressID { get; set; }

    public int ItemRefID { get; set; }

    public short Amount { get; set; }

    public byte Finished { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }
}
