using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_RefCountryNameAndCode")]
    public partial class C_RefCountryNameAndCode
    {
        [Key]
        [StringLength(2)]
        public string code { get; set; }

        [Required]
        [StringLength(64)]
        public string szCountryName { get; set; }
    }
}
