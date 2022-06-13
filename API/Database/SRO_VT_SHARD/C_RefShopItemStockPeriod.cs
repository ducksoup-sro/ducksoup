using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefShopItemStockPeriod")]
    public partial class C_RefShopItemStockPeriod
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string RefShopGroupCodeName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string RefPackageItemCodeName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StockOpeningDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StockExpireDate { get; set; }

        public byte PeriodDevice { get; set; }
    }
}
