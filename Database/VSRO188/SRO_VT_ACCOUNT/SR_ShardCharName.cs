using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SR_ShardCharName
{
    public int UserJID { get; set; }

    public int ShardID { get; set; }

    public string CharName { get; set; } = null!;
}
