using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeFortress")]
    public partial class C_RefSiegeFortress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefSiegeFortress()
        {
            C_RefSiegeBlessBuff = new HashSet<C_RefSiegeBlessBuff>();
            C_RefSiegeFortressRewards = new HashSet<C_RefSiegeFortressRewards>();
        }

        public byte Service { get; set; }

        [Key]
        public int FortressID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string Name { get; set; }

        [Required]
        [StringLength(129)]
        public string NameID128 { get; set; }

        [Required]
        [StringLength(129)]
        public string LinkedTeleportCodeName { get; set; }

        public byte Scale { get; set; }

        public short MaxAdmission { get; set; }

        public byte MaxGuard { get; set; }

        public byte MaxBarricade { get; set; }

        public short TaxTargets { get; set; }

        public int RequestFee { get; set; }

        [Required]
        [StringLength(129)]
        public string CrestPath128 { get; set; }

        [Required]
        [StringLength(129)]
        public string RequestNPCName128 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefSiegeBlessBuff> C_RefSiegeBlessBuff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefSiegeFortressRewards> C_RefSiegeFortressRewards { get; set; }
    }
}
