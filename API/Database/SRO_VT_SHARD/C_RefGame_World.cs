using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGame_World")]
    public partial class C_RefGame_World
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefGame_World()
        {
            C_RefGameWorldBindGameWorldGroup = new HashSet<C_RefGameWorldBindGameWorldGroup>();
            C_RefGameWorldBindTriggerCategory = new HashSet<C_RefGameWorldBindTriggerCategory>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string WorldCodeName128 { get; set; }

        public byte Type { get; set; }

        public short WorldMaxCount { get; set; }

        public short WorldMaxUserCount { get; set; }

        public byte WorldEntryType { get; set; }

        public byte WorldEntranceType { get; set; }

        public byte WorldLeaveType { get; set; }

        public int WorldDurationTime { get; set; }

        public int WorldEmptyRemainTime { get; set; }

        [Required]
        [StringLength(129)]
        public string ConfigGroupCodeName128 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefGameWorldBindGameWorldGroup> C_RefGameWorldBindGameWorldGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefGameWorldBindTriggerCategory> C_RefGameWorldBindTriggerCategory { get; set; }
    }
}
