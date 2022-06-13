using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDropClassSel_Scroll")]
    public partial class C_RefDropClassSel_Scroll
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MonLevel { get; set; }

        [Key]
        [Column(Order = 1)]
        public float ProbGroup1 { get; set; }

        [Key]
        [Column(Order = 2)]
        public float ProbGroup2 { get; set; }

        [Key]
        [Column(Order = 3)]
        public float ProbGroup3 { get; set; }
    }
}
