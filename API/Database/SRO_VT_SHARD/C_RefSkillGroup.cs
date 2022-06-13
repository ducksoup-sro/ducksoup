using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSkillGroup")]
    public partial class C_RefSkillGroup
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string Code { get; set; }
    }
}
