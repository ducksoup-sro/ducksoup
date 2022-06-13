using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    public partial class Tab_RefAISkill
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TacticsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string SkillCodeName { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte ExcuteConditionType { get; set; }

        public int? ExcuteConditionData { get; set; }

        public int? Option { get; set; }
    }
}
