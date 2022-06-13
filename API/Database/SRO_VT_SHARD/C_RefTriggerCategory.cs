using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerCategory")]
    public partial class C_RefTriggerCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTriggerCategory()
        {
            C_RefGameWorldBindTriggerCategory = new HashSet<C_RefGameWorldBindTriggerCategory>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [StringLength(129)]
        public string ObjName128 { get; set; }

        public int IndexNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefGameWorldBindTriggerCategory> C_RefGameWorldBindTriggerCategory { get; set; }
    }
}
