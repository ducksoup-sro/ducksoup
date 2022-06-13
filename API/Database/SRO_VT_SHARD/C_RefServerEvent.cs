using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefServerEvent")]
    public partial class C_RefServerEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefServerEvent()
        {
            C_RefServerEventReward = new HashSet<C_RefServerEventReward>();
        }

        public byte Service { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public byte DetectingTargetType { get; set; }

        public int DetectingTargetID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte NotificationTypeDetectingTarget { get; set; }

        public byte AchievementConditionType { get; set; }

        public short AchievementConditionLevel { get; set; }

        public int AchievementCondition { get; set; }

        public byte RewardTarget { get; set; }

        public int GiveRewardDelayTime { get; set; }

        public byte ActivateClientUI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefServerEventReward> C_RefServerEventReward { get; set; }
    }
}
