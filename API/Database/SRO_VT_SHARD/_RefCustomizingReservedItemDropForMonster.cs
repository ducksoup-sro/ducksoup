﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefCustomizingReservedItemDropForMonster
{
    public int RefMonsterID { get; set; }

    public byte Rarity { get; set; }

    public int Command { get; set; }

    public byte DropGroupType { get; set; }

    public int? Param1 { get; set; }

    public int? Param2 { get; set; }

    public int? Param3 { get; set; }

    public int? Param4 { get; set; }

    public int? Param5 { get; set; }
}
