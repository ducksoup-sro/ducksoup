﻿using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class QuaySoEpoint
{
    public int ID { get; set; }

    public string? UserCash { get; set; }

    public int? Server { get; set; }

    public int? CharID { get; set; }

    public string? CharName { get; set; }

    public int? SP_Own { get; set; }

    public int? SP_Before { get; set; }

    public int? SP_After { get; set; }

    public DateTime? Regdate { get; set; }

    public string? SourcePoint { get; set; }
}
