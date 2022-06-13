using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class dtproperty
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        public int? objectid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string property { get; set; }

        [StringLength(255)]
        public string value { get; set; }

        [StringLength(255)]
        public string uvalue { get; set; }

        [Column(TypeName = "image")]
        public byte[] lvalue { get; set; }

        public int version { get; set; }
    }
}
