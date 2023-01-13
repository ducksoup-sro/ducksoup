using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _Skill_BaoHiem_TNET
{
    public int CharID { get; set; }

    public string? CharName { get; set; }

    public int? SkillBaoHiem { get; set; }

    public DateTime? Regdate { get; set; }

    public DateTime? LastModified { get; set; }
}
