using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _GPHistory
{
    public int ID { get; set; }

    public int GuildID { get; set; }

    public DateTime? UsedTime { get; set; }

    public string CharName { get; set; } = null!;

    public int UsedGP { get; set; }

    public byte Reason { get; set; }
}
