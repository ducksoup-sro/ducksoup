using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTrigger")]
    public partial class C_RefTrigger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTrigger()
        {
            C_RefTriggerBindAction = new HashSet<C_RefTriggerBindAction>();
            C_RefTriggerBindCondition = new HashSet<C_RefTriggerBindCondition>();
            C_RefTriggerBindEvent = new HashSet<C_RefTriggerBindEvent>();
            C_RefTriggerCategoryBindTrigger = new HashSet<C_RefTriggerCategoryBindTrigger>();
            C_RefTriggerVariable = new HashSet<C_RefTriggerVariable>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        public byte IsActive { get; set; }

        public byte IsRepeat { get; set; }

        [StringLength(513)]
        public string Comment512 { get; set; }

        public int IndexNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindAction> C_RefTriggerBindAction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindCondition> C_RefTriggerBindCondition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindEvent> C_RefTriggerBindEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerCategoryBindTrigger> C_RefTriggerCategoryBindTrigger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerVariable> C_RefTriggerVariable { get; set; }
    }
}
