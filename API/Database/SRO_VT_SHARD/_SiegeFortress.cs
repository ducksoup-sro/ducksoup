﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _SiegeFortress
{
    public int FortressID { get; set; }

    public int GuildID { get; set; }

    public short TaxRatio { get; set; }

    public long Tax { get; set; }

    public byte NPCHired { get; set; }

    public int TempGuildID { get; set; }

    public string? Introduction { get; set; }

    public DateTime? CreatedDungeonTime { get; set; }

    public byte? CreatedDungeonCount { get; set; }

    public byte IntroductionModificationPermission { get; set; }
}
