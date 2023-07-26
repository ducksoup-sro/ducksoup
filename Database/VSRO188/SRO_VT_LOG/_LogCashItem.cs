using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_LOG;

public partial class _LogCashItem
{
    public int RefItemID { get; set; }

    public int CharID { get; set; }

    public short Cnt { get; set; }

    public DateTime EventTime { get; set; }

    public long Serial64 { get; set; }
}
