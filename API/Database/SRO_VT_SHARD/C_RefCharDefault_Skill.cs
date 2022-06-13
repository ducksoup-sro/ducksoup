using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefCharDefault_Skill")]
    public partial class C_RefCharDefault_Skill
    {
        [Key]
        [Column(Order = 0)]
        public byte Race { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillID { get; set; }
    }
}
