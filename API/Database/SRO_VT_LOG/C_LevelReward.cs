using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_LevelReward")]
    public partial class C_LevelReward
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int charid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int level { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime date { get; set; }
    }
}
