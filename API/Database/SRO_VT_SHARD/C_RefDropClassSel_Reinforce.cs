using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDropClassSel_Reinforce")]
    public partial class C_RefDropClassSel_Reinforce
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
    }
}
