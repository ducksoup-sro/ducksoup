using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_SiegeFortressBattleRecord")]
    public partial class C_SiegeFortressBattleRecord
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int KillCount { get; set; }

        public int KilledCount { get; set; }

        public DateTime RankUpDate { get; set; }

        public byte CurRank { get; set; }

        public virtual C_SiegeFortress C_SiegeFortress { get; set; }
    }
}
