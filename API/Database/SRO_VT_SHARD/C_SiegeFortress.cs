using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_SiegeFortress")]
    public partial class C_SiegeFortress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_SiegeFortress()
        {
            C_SiegeFortressBattleRecord = new HashSet<C_SiegeFortressBattleRecord>();
            C_SiegeFortressItemForge = new HashSet<C_SiegeFortressItemForge>();
            C_SiegeFortressObject = new HashSet<C_SiegeFortressObject>();
            C_SiegeFortressRequest = new HashSet<C_SiegeFortressRequest>();
            C_SiegeFortressStoneState = new HashSet<C_SiegeFortressStoneState>();
            C_SiegeFortressStruct = new HashSet<C_SiegeFortressStruct>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        public int GuildID { get; set; }

        public short TaxRatio { get; set; }

        public long Tax { get; set; }

        public byte NPCHired { get; set; }

        public int TempGuildID { get; set; }

        [StringLength(120)]
        public string Introduction { get; set; }

        public DateTime? CreatedDungeonTime { get; set; }

        public byte? CreatedDungeonCount { get; set; }

        public byte IntroductionModificationPermission { get; set; }

        public virtual C_Guild C_Guild { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressBattleRecord> C_SiegeFortressBattleRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressItemForge> C_SiegeFortressItemForge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressObject> C_SiegeFortressObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressRequest> C_SiegeFortressRequest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressStoneState> C_SiegeFortressStoneState { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressStruct> C_SiegeFortressStruct { get; set; }
    }
}
