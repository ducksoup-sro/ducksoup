using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SR_CharName
{
    public int UserJID { get; set; }

    public short ShardID { get; set; }

    public string CharID_1 { get; set; } = null!;

    public string? CharID_2 { get; set; }

    public string? CharID_3 { get; set; }
}
