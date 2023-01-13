using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class SK_ResetSkillLog
{
    public int id { get; set; }

    public int? JID { get; set; }

    public string? struserid { get; set; }

    public string? charname { get; set; }

    public string? SkillDown { get; set; }

    public string? NewSkill { get; set; }

    public string? SilkDown { get; set; }

    public string? server { get; set; }

    public DateTime? TimeReset { get; set; }
}
