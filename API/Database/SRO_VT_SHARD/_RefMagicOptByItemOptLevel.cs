﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefMagicOptByItemOptLevel
{
    public int Link { get; set; }

    public short RefMagicOptID { get; set; }

    public int MagicOptValue { get; set; }

    public byte TooltipType { get; set; }

    public string TooltipCodename { get; set; } = null!;
}
