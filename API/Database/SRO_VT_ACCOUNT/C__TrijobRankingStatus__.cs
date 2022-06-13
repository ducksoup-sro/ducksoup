using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("__TrijobRankingStatus__")]
    public partial class C__TrijobRankingStatus__
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShardID { get; set; }

        public byte Status { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime UpdateTime { get; set; }
    }
}
