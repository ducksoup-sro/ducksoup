using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerCommon")]
    public partial class C_RefTriggerCommon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTriggerCommon()
        {
            C_RefTriggerAction = new HashSet<C_RefTriggerAction>();
            C_RefTriggerCondition = new HashSet<C_RefTriggerCondition>();
            C_RefTriggerEvent = new HashSet<C_RefTriggerEvent>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string ObjName128 { get; set; }

        public short TID1 { get; set; }

        public short TID2 { get; set; }

        public short TID3 { get; set; }

        public short TID4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerAction> C_RefTriggerAction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerCondition> C_RefTriggerCondition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerEvent> C_RefTriggerEvent { get; set; }
    }
}
