﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefSiegeDungeon
{
    public byte Service { get; set; }

    public int FortressID { get; set; }

    public int WorldID { get; set; }

    public byte MaxCreateCount { get; set; }

    public long EntryGold { get; set; }

    public int EntryGP { get; set; }
}
