using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _Memo
{
    public long ID64 { get; set; }

    public int CharID { get; set; }

    public string FromCharName { get; set; } = null!;

    public string? Message { get; set; }

    public DateTime Date { get; set; }

    public byte Status { get; set; }

    public int? RefObjID { get; set; }
}
