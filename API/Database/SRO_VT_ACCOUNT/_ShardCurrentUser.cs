﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class _ShardCurrentUser
{
    public int nID { get; set; }

    public int nShardID { get; set; }

    public int nUserCount { get; set; }

    public DateTime dLogDate { get; set; }
}
