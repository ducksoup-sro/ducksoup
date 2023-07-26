using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefSkill
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public int GroupID { get; set; }

    public string Basic_Code { get; set; } = null!;

    public string Basic_Name { get; set; } = null!;

    public string Basic_Group { get; set; } = null!;

    public int Basic_Original { get; set; }

    public byte Basic_Level { get; set; }

    public byte Basic_Activity { get; set; }

    public int Basic_ChainCode { get; set; }

    public int Basic_RecycleCost { get; set; }

    public int Action_PreparingTime { get; set; }

    public int Action_CastingTime { get; set; }

    public int Action_ActionDuration { get; set; }

    public int Action_ReuseDelay { get; set; }

    public int Action_CoolTime { get; set; }

    public int Action_FlyingSpeed { get; set; }

    public byte Action_Interruptable { get; set; }

    public int Action_Overlap { get; set; }

    public byte Action_AutoAttackType { get; set; }

    public byte Action_InTown { get; set; }

    public short Action_Range { get; set; }

    public byte Target_Required { get; set; }

    public byte TargetType_Animal { get; set; }

    public byte TargetType_Land { get; set; }

    public byte TargetType_Building { get; set; }

    public byte TargetGroup_Self { get; set; }

    public byte TargetGroup_Ally { get; set; }

    public byte TargetGroup_Party { get; set; }

    public byte TargetGroup_Enemy_M { get; set; }

    public byte TargetGroup_Enemy_P { get; set; }

    public byte TargetGroup_Neutral { get; set; }

    public byte TargetGroup_DontCare { get; set; }

    public byte TargetEtc_SelectDeadBody { get; set; }

    public int ReqCommon_Mastery1 { get; set; }

    public int ReqCommon_Mastery2 { get; set; }

    public byte ReqCommon_MasteryLevel1 { get; set; }

    public byte ReqCommon_MasteryLevel2 { get; set; }

    public short ReqCommon_Str { get; set; }

    public short ReqCommon_Int { get; set; }

    public int ReqLearn_Skill1 { get; set; }

    public int ReqLearn_Skill2 { get; set; }

    public int ReqLearn_Skill3 { get; set; }

    public byte ReqLearn_SkillLevel1 { get; set; }

    public byte ReqLearn_SkillLevel2 { get; set; }

    public byte ReqLearn_SkillLevel3 { get; set; }

    public int ReqLearn_SP { get; set; }

    public byte ReqLearn_Race { get; set; }

    public byte Req_Restriction1 { get; set; }

    public byte Req_Restriction2 { get; set; }

    public byte ReqCast_Weapon1 { get; set; }

    public byte ReqCast_Weapon2 { get; set; }

    public short Consume_HP { get; set; }

    public short Consume_MP { get; set; }

    public short Consume_HPRatio { get; set; }

    public short Consume_MPRatio { get; set; }

    public byte Consume_WHAN { get; set; }

    public byte UI_SkillTab { get; set; }

    public byte UI_SkillPage { get; set; }

    public byte UI_SkillColumn { get; set; }

    public byte UI_SkillRow { get; set; }

    public string UI_IconFile { get; set; } = null!;

    public string UI_SkillName { get; set; } = null!;

    public string UI_SkillToolTip { get; set; } = null!;

    public string UI_SkillToolTip_Desc { get; set; } = null!;

    public string UI_SkillStudy_Desc { get; set; } = null!;

    public short AI_AttackChance { get; set; }

    public byte AI_SkillType { get; set; }

    public int Param1 { get; set; }

    public int Param2 { get; set; }

    public int Param3 { get; set; }

    public int Param4 { get; set; }

    public int Param5 { get; set; }

    public int Param6 { get; set; }

    public int Param7 { get; set; }

    public int Param8 { get; set; }

    public int Param9 { get; set; }

    public int Param10 { get; set; }

    public int Param11 { get; set; }

    public int Param12 { get; set; }

    public int Param13 { get; set; }

    public int Param14 { get; set; }

    public int Param15 { get; set; }

    public int Param16 { get; set; }

    public int Param17 { get; set; }

    public int Param18 { get; set; }

    public int Param19 { get; set; }

    public int Param20 { get; set; }

    public int Param21 { get; set; }

    public int Param22 { get; set; }

    public int Param23 { get; set; }

    public int Param24 { get; set; }

    public int Param25 { get; set; }

    public int? Param26 { get; set; }

    public int? Param27 { get; set; }

    public int? Param28 { get; set; }

    public int? Param29 { get; set; }

    public int? Param30 { get; set; }

    public int? Param31 { get; set; }

    public int? Param32 { get; set; }

    public int? Param33 { get; set; }

    public int? Param34 { get; set; }

    public int? Param35 { get; set; }

    public int? Param36 { get; set; }

    public int? Param37 { get; set; }

    public int? Param38 { get; set; }

    public int? Param39 { get; set; }

    public int? Param40 { get; set; }

    public int? Param41 { get; set; }

    public int? Param42 { get; set; }

    public int? Param43 { get; set; }

    public int? Param44 { get; set; }

    public int? Param45 { get; set; }

    public int? Param46 { get; set; }

    public int? Param47 { get; set; }

    public int? Param48 { get; set; }

    public int? Param49 { get; set; }

    public int? Param50 { get; set; }

    public bool ParamsContains(int value)
    {
        if (Param1 == value) return true;
        if (Param2 == value) return true;
        if (Param3 == value) return true;
        if (Param4 == value) return true;
        if (Param5 == value) return true;
        if (Param6 == value) return true;
        if (Param7 == value) return true;
        if (Param8 == value) return true;
        if (Param9 == value) return true;
        if (Param10 == value) return true;
        if (Param11 == value) return true;
        if (Param12 == value) return true;
        if (Param13 == value) return true;
        if (Param14 == value) return true;
        if (Param15 == value) return true;
        if (Param16 == value) return true;
        if (Param17 == value) return true;
        if (Param18 == value) return true;
        if (Param19 == value) return true;
        if (Param20 == value) return true;
        if (Param21 == value) return true;
        if (Param22 == value) return true;
        if (Param23 == value) return true;
        if (Param24 == value) return true;
        if (Param25 == value) return true;
        if (Param26 == value) return true;
        if (Param27 == value) return true;
        if (Param28 == value) return true;
        if (Param29 == value) return true;
        if (Param30 == value) return true;
        if (Param31 == value) return true;
        if (Param32 == value) return true;
        if (Param33 == value) return true;
        if (Param34 == value) return true;
        if (Param35 == value) return true;
        if (Param36 == value) return true;
        if (Param37 == value) return true;
        if (Param38 == value) return true;
        if (Param39 == value) return true;
        if (Param40 == value) return true;
        if (Param41 == value) return true;
        if (Param42 == value) return true;
        if (Param43 == value) return true;
        if (Param44 == value) return true;
        if (Param45 == value) return true;
        if (Param46 == value) return true;
        if (Param47 == value) return true;
        if (Param48 == value) return true;
        if (Param49 == value) return true;
        if (Param50 == value) return true;

        return false;
    }
}