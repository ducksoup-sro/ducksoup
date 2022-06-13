using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_CasGMChatLog")]
    public partial class C_CasGMChatLog
    {
        [Key]
        public int nSerial { get; set; }

        [Required]
        [StringLength(20)]
        public string szGM { get; set; }

        public short wShardID { get; set; }

        [Required]
        [StringLength(64)]
        public string szCharName { get; set; }

        public int nCasSerial { get; set; }

        [StringLength(4000)]
        public string szGMChatLog { get; set; }

        public DateTime dWritten { get; set; }
    }
}
