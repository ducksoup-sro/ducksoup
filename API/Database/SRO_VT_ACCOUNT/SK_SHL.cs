using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SK_SHL
{
    public int idx { get; set; }

    public int JID { get; set; }

    public int COS { get; set; }

    public int CGS { get; set; }

    public int HOS { get; set; }

    public int HGS { get; set; }

    public DateTime event_time { get; set; }
}
