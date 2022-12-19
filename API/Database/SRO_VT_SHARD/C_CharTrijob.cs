using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharTrijob")]
    public partial class C_CharTrijob
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_CharTrijob()
        {
            C_CharTrijobSafeTrade = new HashSet<C_CharTrijobSafeTrade>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public byte JobType { get; set; }

        public byte Level { get; set; }

        public int Exp { get; set; }

        public int Contribution { get; set; }

        public int Reward { get; set; }
        
        public virtual C_Char C_Char { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_CharTrijobSafeTrade> C_CharTrijobSafeTrade { get; set; }
    }
}
