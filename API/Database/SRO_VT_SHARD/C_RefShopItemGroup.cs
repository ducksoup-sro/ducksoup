using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefShopItemGroup")]
    public partial class C_RefShopItemGroup
    {
        public int Service { get; set; }

        [Key]
        public int GroupID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string StrID128_Group { get; set; }
    }
}
