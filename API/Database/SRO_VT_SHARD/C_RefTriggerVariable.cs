using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerVariable")]
    public partial class C_RefTriggerVariable
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int BindTriggerID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(33)]
        public string Type { get; set; }

        public int Value { get; set; }

        [StringLength(129)]
        public string Comment128 { get; set; }

        public virtual C_RefTrigger C_RefTrigger { get; set; }
    }
}
