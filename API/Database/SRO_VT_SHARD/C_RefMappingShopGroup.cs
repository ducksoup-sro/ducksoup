using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMappingShopGroup")]
    public partial class C_RefMappingShopGroup
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string RefShopGroupCodeName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string RefShopCodeName { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
