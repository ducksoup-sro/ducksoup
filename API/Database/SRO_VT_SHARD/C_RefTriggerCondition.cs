using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerCondition")]
    public partial class C_RefTriggerCondition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTriggerCondition()
        {
            C_RefTriggerBindCondition = new HashSet<C_RefTriggerBindCondition>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        public int RefTriggerCommonID { get; set; }

        [Required]
        [StringLength(20)]
        public string OnTrue { get; set; }

        [Required]
        [StringLength(20)]
        public string OnFalse { get; set; }

        public short Sequence { get; set; }

        [Required]
        [StringLength(129)]
        public string ParamGroupCodeName128 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindCondition> C_RefTriggerBindCondition { get; set; }

        public virtual C_RefTriggerCommon C_RefTriggerCommon { get; set; }
    }
}
