﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefSiegeBlessBuff
{
    public byte Service { get; set; }

    public int BlessID { get; set; }

    public int FortressID { get; set; }

    public int RefBlessBuffID { get; set; }

    public long? NeedGold { get; set; }

    public int? NeedGP { get; set; }
}
