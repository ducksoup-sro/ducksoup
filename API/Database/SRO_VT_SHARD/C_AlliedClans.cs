using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_AlliedClans")]
    public partial class C_AlliedClans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_AlliedClans()
        {
            C_Guild8 = new HashSet<C_Guild>();
        }

        public int ID { get; set; }

        public int? Ally1 { get; set; }

        public int? Ally2 { get; set; }

        public int? Ally3 { get; set; }

        public int? Ally4 { get; set; }

        public int? Ally5 { get; set; }

        public int? Ally6 { get; set; }

        public int? Ally7 { get; set; }

        public int? Ally8 { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FoundationDate { get; set; }

        public int LastCrestRev { get; set; }

        public int CurCrestRev { get; set; }

        public virtual C_Guild C_Guild { get; set; }

        public virtual C_Guild C_Guild1 { get; set; }

        public virtual C_Guild C_Guild2 { get; set; }

        public virtual C_Guild C_Guild3 { get; set; }

        public virtual C_Guild C_Guild4 { get; set; }

        public virtual C_Guild C_Guild5 { get; set; }

        public virtual C_Guild C_Guild6 { get; set; }

        public virtual C_Guild C_Guild7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Guild> C_Guild8 { get; set; }
    }
}
