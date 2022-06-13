using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGameWorldGroup_Config")]
    public partial class C_RefGameWorldGroup_Config
    {
        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string GroupCodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string ValueCodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string Value { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }
    }
}
