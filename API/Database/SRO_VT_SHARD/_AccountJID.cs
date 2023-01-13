using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _AccountJID
{
    public string AccountID { get; set; } = null!;

    public int JID { get; set; }

    public long Gold { get; set; }
}
