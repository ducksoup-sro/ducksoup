using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class Tab_RefAISkill
{
    public int TacticsID { get; set; }

    public string SkillCodeName { get; set; } = null!;

    public byte ExcuteConditionType { get; set; }

    public int? ExcuteConditionData { get; set; }

    public int? Option { get; set; }
}
