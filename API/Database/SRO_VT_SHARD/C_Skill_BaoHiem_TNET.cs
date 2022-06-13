using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Skill_BaoHiem_TNET")]
    public partial class C_Skill_BaoHiem_TNET
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [StringLength(20)]
        public string CharName { get; set; }

        public int? SkillBaoHiem { get; set; }

        public DateTime? Regdate { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
