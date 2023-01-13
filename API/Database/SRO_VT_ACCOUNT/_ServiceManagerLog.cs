using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class _ServiceManagerLog
{
    public int nUserID { get; set; }

    public DateTime EventTime { get; set; }

    public string szLog { get; set; } = null!;
}
