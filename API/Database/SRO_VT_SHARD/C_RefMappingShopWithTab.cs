using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMappingShopWithTab")]
    public partial class C_RefMappingShopWithTab
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string RefShopCodeName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string RefTabGroupCodeName { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
