using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class _SecurityDescription
{
    public int nID { get; set; }

    public string szName { get; set; } = null!;

    public string szDesc { get; set; } = null!;
}
