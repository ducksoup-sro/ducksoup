using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefRentItem
{
    public int service { get; set; }

    public string RentCodeName { get; set; } = null!;

    public int RefItemID { get; set; }

    public byte CanDelete { get; set; }

    public byte CnaRecharge { get; set; }

    public int? RentType { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public byte? TimeCnt { get; set; }

    public int? Time1 { get; set; }

    public int? Time2 { get; set; }

    public int? Time3 { get; set; }

    public int? Time4 { get; set; }

    public int? Time5 { get; set; }
}
