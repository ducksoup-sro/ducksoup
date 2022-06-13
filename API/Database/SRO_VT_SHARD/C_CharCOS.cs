using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharCOS")]
    public partial class C_CharCOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_CharCOS()
        {
            C_InvCOS = new HashSet<C_InvCOS>();
        }

        public int ID { get; set; }

        public int OwnerCharID { get; set; }

        public int RefCharID { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public int KeeperNPC { get; set; }

        public byte State { get; set; }

        [StringLength(16)]
        public string CharName { get; set; }

        public byte Lvl { get; set; }

        public long ExpOffset { get; set; }

        public short HGP { get; set; }

        public int PetOption { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RentEndTime { get; set; }

        public virtual C_Char C_Char { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_InvCOS> C_InvCOS { get; set; }
    }
}
