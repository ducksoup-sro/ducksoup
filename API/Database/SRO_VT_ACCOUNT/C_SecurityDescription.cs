using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_SecurityDescription")]
    public partial class C_SecurityDescription
    {
        [Key]
        [Column(Order = 0)]
        public int nID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string szName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string szDesc { get; set; }
    }
}
