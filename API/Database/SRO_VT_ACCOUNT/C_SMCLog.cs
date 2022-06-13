using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_SMCLog")]
    public partial class C_SMCLog
    {
        [Key]
        [Column(Order = 0)]
        public string szUserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Catagory { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string szLog { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime dLogDate { get; set; }
    }
}
