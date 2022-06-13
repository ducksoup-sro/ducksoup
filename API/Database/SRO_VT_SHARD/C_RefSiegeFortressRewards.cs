using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeFortressRewards")]
    public partial class C_RefSiegeFortressRewards
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte RewardTypeID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RewardValue { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte RewardCount { get; set; }

        public virtual C_RefSiegeFortress C_RefSiegeFortress { get; set; }
    }
}
