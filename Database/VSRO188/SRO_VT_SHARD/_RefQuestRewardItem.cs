namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _RefQuestRewardItem
{
    public byte Service { get; set; }

    public int QuestID { get; set; }

    public string QuestCodeName { get; set; } = null!;

    public byte RewardType { get; set; }

    public string ItemCodeName { get; set; } = null!;

    public string OptionalItemCode { get; set; } = null!;

    public int OptionalItemCnt { get; set; }

    public int AchieveQuantity { get; set; }

    public string RentItemCodeName { get; set; } = null!;

    public int Param1 { get; set; }

    public string Param1_Desc { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc { get; set; } = null!;
}
