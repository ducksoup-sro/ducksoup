using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_WebShop_SRO_Log")]
    public partial class C_WebShop_SRO_Log
    {
        public long ID { get; set; }

        public int JID { get; set; }

        [Required]
        [StringLength(16)]
        public string IP { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Balance_Before_Buy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Balance_After_Buy { get; set; }
    }
}
