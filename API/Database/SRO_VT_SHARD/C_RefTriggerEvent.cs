using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerEvent")]
    public partial class C_RefTriggerEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTriggerEvent()
        {
            C_RefTriggerBindEvent = new HashSet<C_RefTriggerBindEvent>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        public int RefTriggerCommonID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindEvent> C_RefTriggerBindEvent { get; set; }

        public virtual C_RefTriggerCommon C_RefTriggerCommon { get; set; }
    }
}
