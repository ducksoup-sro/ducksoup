using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSkillMastery")]
    public partial class C_RefSkillMastery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string Code { get; set; }

        public byte Weapon { get; set; }
    }
}
