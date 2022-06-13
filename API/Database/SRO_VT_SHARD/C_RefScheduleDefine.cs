using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefScheduleDefine")]
    public partial class C_RefScheduleDefine
    {
        [Key]
        public int ScheduleDefineIdx { get; set; }

        [Required]
        [StringLength(124)]
        public string ScheduleName { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
    }
}
