using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefServerEventReward_SpawnMonster")]
    public partial class C_RefServerEventReward_SpawnMonster
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerRewardID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        [Key]
        [Column(Order = 2)]
        public float PosX { get; set; }

        [Key]
        [Column(Order = 3)]
        public float PosY { get; set; }

        [Key]
        [Column(Order = 4)]
        public float PosZ { get; set; }

        public virtual C_RefServerEventReward C_RefServerEventReward { get; set; }
    }
}
