﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _Log_SEEK_N_DESTROY_ITEM_FAST
{
    public DateTime? DeletedTime { get; set; }

    public byte? OwnerType { get; set; }

    public int? OwnerID { get; set; }

    public long? ID64 { get; set; }

    public string? CodeName { get; set; }

    public byte? OptLevel { get; set; }

    public long? Variance { get; set; }

    public int? Data { get; set; }
}
