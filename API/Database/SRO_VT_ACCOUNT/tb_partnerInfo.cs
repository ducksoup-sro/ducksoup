using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class tb_partnerInfo
{
    public string partnerID { get; set; } = null!;

    public string? partnerName { get; set; }

    public string? partnerPass { get; set; }

    public int? balance { get; set; }

    public DateTime? udate { get; set; }
}
