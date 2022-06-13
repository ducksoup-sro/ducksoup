using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_Shard")]
    public partial class C_Shard
    {
        [Key]
        public short nID { get; set; }

        public byte nFarmID { get; set; }

        public byte nContentID { get; set; }

        [Required]
        [StringLength(32)]
        public string szName { get; set; }

        [Required]
        [StringLength(256)]
        public string szDesc { get; set; }

        [Required]
        [StringLength(256)]
        public string szDBConfig { get; set; }

        public short nMaxUser { get; set; }

        public short nStartupServerID { get; set; }

        public byte nStatus { get; set; }

        public byte nCurrentUserRatio { get; set; }
    }
}
