using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class _SMCLog
{
    public string szUserID { get; set; } = null!;

    public byte Catagory { get; set; }

    public string szLog { get; set; } = null!;

    public DateTime dLogDate { get; set; }
}
