using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _DeletedChar
{
    public int CharID { get; set; }

    public int UserJID { get; set; }

    public DateTime DeletedDate { get; set; }
}
