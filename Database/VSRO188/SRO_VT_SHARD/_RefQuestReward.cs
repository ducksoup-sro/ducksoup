namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefQuestReward
{
    public byte Service { get; set; }

    public int QuestID { get; set; }

    public string QuestCodeName { get; set; } = null!;

    public byte IsView { get; set; }

    public byte IsBasicReward { get; set; }

    public byte IsItemReward { get; set; }

    public byte IsCheckCondition { get; set; }

    public byte IsCheckCountry { get; set; }

    public byte IsCheckClass { get; set; }

    public byte IsCheckGender { get; set; }

    public int Gold { get; set; }

    public int Exp { get; set; }

    public int SPExp { get; set; }

    public int SP { get; set; }

    public int AP { get; set; }

    public string APType { get; set; } = null!;

    public byte Hwan { get; set; }

    public byte Inventory { get; set; }

    public byte ItemRewardType { get; set; }

    public byte SelectionCnt { get; set; }

    public long Param1 { get; set; }

    public string Param1_Desc { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc { get; set; } = null!;

    public int Param3 { get; set; }

    public string Param3_Desc { get; set; } = null!;
}
