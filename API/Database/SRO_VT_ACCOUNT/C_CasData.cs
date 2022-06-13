using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_CasData")]
    public partial class C_CasData
    {
        [Key]
        public int nSerial { get; set; }

        public byte nCategory { get; set; }

        public DateTime dReportDate { get; set; }

        public short wShardID { get; set; }

        public int dwUserJID { get; set; }

        [Required]
        [StringLength(64)]
        public string szCharName { get; set; }

        [StringLength(64)]
        public string szTgtCharName { get; set; }

        [Required]
        [StringLength(40)]
        public string szMailAddress { get; set; }

        [Required]
        [StringLength(512)]
        public string szStatement { get; set; }

        public byte nStatus { get; set; }

        public DateTime? dProcessDate { get; set; }

        [StringLength(20)]
        public string szProcessedGM { get; set; }

        [StringLength(128)]
        public string szMemo { get; set; }

        [StringLength(1024)]
        public string szAnswer { get; set; }

        public byte btUserChecked { get; set; }

        [Required]
        [StringLength(4000)]
        public string szChatLog { get; set; }
    }
}
