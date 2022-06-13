using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_LoginLogoutStatistics")]
    public partial class C_LoginLogoutStatistics
    {
        [Key]
        [Column(Order = 0)]
        public int nIdx { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nJID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nIP { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "smalldatetime")]
        public DateTime dLogin { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime dLogout { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte byReserved { get; set; }
    }
}
