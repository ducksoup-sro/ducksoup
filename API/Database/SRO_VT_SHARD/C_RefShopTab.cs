using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefShopTab")]
    public partial class C_RefShopTab
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string RefTabGroupCodeName { get; set; }

        [Required]
        [StringLength(129)]
        public string StrID128_Tab { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
