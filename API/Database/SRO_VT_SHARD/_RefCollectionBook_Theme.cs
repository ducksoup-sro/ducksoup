﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefCollectionBook_Theme
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string ObjName128 { get; set; } = null!;

    public string Name128 { get; set; } = null!;

    public string Desc128 { get; set; } = null!;

    public int CompleteNum { get; set; }
}
