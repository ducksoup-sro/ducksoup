using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefServerEventReward_ExpUPForPlayers")]
    public partial class C_RefServerEventReward_ExpUPForPlayers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerRewardID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplyTime { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte ApplyExpRatio { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte ApplySExpRatio { get; set; }

        public virtual C_RefServerEventReward C_RefServerEventReward { get; set; }
    }
}
