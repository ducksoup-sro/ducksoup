using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGachaCode")]
    public partial class C_RefGachaCode
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GachaSetID { get; set; }
    }
}
