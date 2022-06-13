using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerAction")]
    public partial class C_RefTriggerAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefTriggerAction()
        {
            C_RefTriggerBindAction = new HashSet<C_RefTriggerBindAction>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        public int RefTriggerCommonID { get; set; }

        public int Delay { get; set; }

        [Required]
        [StringLength(129)]
        public string ParamGroupCodeName128 { get; set; }

        public virtual C_RefTriggerCommon C_RefTriggerCommon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTriggerBindAction> C_RefTriggerBindAction { get; set; }
    }
}
