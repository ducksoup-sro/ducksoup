﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _WebShop_SRO_Log
{
    public long ID { get; set; }

    public int JID { get; set; }

    public string IP { get; set; } = null!;

    public string CodeName128 { get; set; } = null!;

    public decimal Balance_Before_Buy { get; set; }

    public decimal Balance_After_Buy { get; set; }
}
