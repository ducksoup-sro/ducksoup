using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_PrivilegedIP")]
    public partial class C_PrivilegedIP
    {
        [Key]
        [Column(Order = 0)]
        public byte IP1 { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte IP2 { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte IP3 { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte IP4 { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte IP5 { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte IP6 { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte IP7 { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte IP8 { get; set; }
    }
}
