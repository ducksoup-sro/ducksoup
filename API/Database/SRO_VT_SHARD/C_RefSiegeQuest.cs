using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeQuest")]
    public partial class C_RefSiegeQuest
    {
        public byte Service { get; set; }

        [Key]
        public int QuestID { get; set; }

        [Required]
        [StringLength(129)]
        public string QuestName { get; set; }

        public byte QuestType { get; set; }

        public byte RewardConditionTargetCount { get; set; }

        public byte IsAccumulation { get; set; }
    }
}
