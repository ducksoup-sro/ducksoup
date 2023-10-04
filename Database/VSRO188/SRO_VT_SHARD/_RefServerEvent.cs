namespace Database.VSRO188.SRO_VT_SHARD;

public class _RefServerEvent
{
    public byte Service { get; set; }

    public int ID { get; set; }

    public byte DetectingTargetType { get; set; }

    public int DetectingTargetID { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public byte NotificationTypeDetectingTarget { get; set; }

    public byte AchievementConditionType { get; set; }

    public short AchievementConditionLevel { get; set; }

    public int AchievementCondition { get; set; }

    public byte RewardTarget { get; set; }

    public int GiveRewardDelayTime { get; set; }

    public byte ActivateClientUI { get; set; }
}