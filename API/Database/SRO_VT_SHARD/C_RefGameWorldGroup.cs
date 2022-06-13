using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGameWorldGroup")]
    public partial class C_RefGameWorldGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefGameWorldGroup()
        {
            C_RefGameWorldBindGameWorldGroup = new HashSet<C_RefGameWorldBindGameWorldGroup>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string ObjName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string ConfigGroupCodeName128 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefGameWorldBindGameWorldGroup> C_RefGameWorldBindGameWorldGroup { get; set; }
    }
}
