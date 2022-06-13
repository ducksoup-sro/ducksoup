using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDropClassSel_Ammo")]
    public partial class C_RefDropClassSel_Ammo
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

        [Key]
        [Column(Order = 4)]
        public float ProbGroup4 { get; set; }

        [Key]
        [Column(Order = 5)]
        public float ProbGroup5 { get; set; }

        [Key]
        [Column(Order = 6)]
        public float ProbGroup6 { get; set; }
    }
}
