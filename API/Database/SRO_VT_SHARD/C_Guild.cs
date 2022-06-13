using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Guild")]
    public partial class C_Guild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Guild()
        {
            C_AlliedClans = new HashSet<C_AlliedClans>();
            C_AlliedClans1 = new HashSet<C_AlliedClans>();
            C_AlliedClans2 = new HashSet<C_AlliedClans>();
            C_AlliedClans3 = new HashSet<C_AlliedClans>();
            C_AlliedClans4 = new HashSet<C_AlliedClans>();
            C_AlliedClans5 = new HashSet<C_AlliedClans>();
            C_AlliedClans6 = new HashSet<C_AlliedClans>();
            C_AlliedClans7 = new HashSet<C_AlliedClans>();
            C_GuildChest = new HashSet<C_GuildChest>();
            C_GuildMember = new HashSet<C_GuildMember>();
            C_GuildWar = new HashSet<C_GuildWar>();
            C_GuildWar1 = new HashSet<C_GuildWar>();
            C_SiegeFortress = new HashSet<C_SiegeFortress>();
            C_SiegeFortressRequest = new HashSet<C_SiegeFortressRequest>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public byte Lvl { get; set; }

        public int GatheredSP { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FoundationDate { get; set; }

        public int? Alliance { get; set; }

        [StringLength(129)]
        public string MasterCommentTitle { get; set; }

        [StringLength(2049)]
        public string MasterComment { get; set; }

        public int? Booty { get; set; }

        public long Gold { get; set; }

        public int LastCrestRev { get; set; }

        public int CurCrestRev { get; set; }

        public byte MercenaryAttr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_AlliedClans> C_AlliedClans7 { get; set; }

        public virtual C_AlliedClans C_AlliedClans8 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_GuildChest> C_GuildChest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_GuildMember> C_GuildMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_GuildWar> C_GuildWar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_GuildWar> C_GuildWar1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortress> C_SiegeFortress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_SiegeFortressRequest> C_SiegeFortressRequest { get; set; }
    }
}
