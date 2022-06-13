using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_SecurityDescriptionGroup")]
    public partial class C_SecurityDescriptionGroup
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte nID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(32)]
        public string szName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string szDesc { get; set; }
    }
}
