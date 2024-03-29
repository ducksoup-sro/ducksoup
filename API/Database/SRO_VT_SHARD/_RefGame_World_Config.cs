﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefGame_World_Config
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string GroupCodeName128 { get; set; } = null!;

    public string ValueCodeName128 { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Type { get; set; } = null!;
}
