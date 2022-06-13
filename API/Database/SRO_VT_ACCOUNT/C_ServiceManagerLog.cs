using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_ServiceManagerLog")]
    public partial class C_ServiceManagerLog
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nUserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime EventTime { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string szLog { get; set; }
    }
}
