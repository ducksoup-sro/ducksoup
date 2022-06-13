using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_ModuleVersionFile")]
    public partial class C_ModuleVersionFile
    {
        [Key]
        public int nID { get; set; }

        public int nVersion { get; set; }

        public byte nDivisionID { get; set; }

        public byte nContentID { get; set; }

        public byte nModuleID { get; set; }

        [Required]
        [StringLength(256)]
        public string szFilename { get; set; }

        [Required]
        [StringLength(256)]
        public string szPath { get; set; }

        public int nFileSize { get; set; }

        public byte nFileType { get; set; }

        public int nFileTypeVersion { get; set; }

        public byte nToBePacked { get; set; }

        public DateTime timeModified { get; set; }

        public byte nValid { get; set; }
    }
}
