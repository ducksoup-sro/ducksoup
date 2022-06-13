using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_ModuleVersion")]
    public partial class C_ModuleVersion
    {
        [Key]
        public int nID { get; set; }

        public byte nDivisionID { get; set; }

        public byte nContentID { get; set; }

        public byte nModuleID { get; set; }

        public int nVersion { get; set; }

        [Required]
        [StringLength(64)]
        public string szVersion { get; set; }

        [Required]
        [StringLength(256)]
        public string szDesc { get; set; }

        public byte nValid { get; set; }
    }
}
