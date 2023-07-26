using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class Tab_RefRanking_RobberActivity
{
    public byte Rank { get; set; }

    public string NickName { get; set; } = null!;

    public byte JobLevel { get; set; }

    public int JobExp { get; set; }

    public short Country { get; set; }
}
