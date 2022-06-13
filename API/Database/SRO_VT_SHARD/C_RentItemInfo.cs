using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RentItemInfo")]
    public partial class C_RentItemInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long nItemDBID { get; set; }

        public int nRentType { get; set; }

        public short nCanDelete { get; set; }

        public short nCanRecharge { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PeriodBeginTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PeriodEndTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? MeterRateTime { get; set; }

        public short? nPackingState { get; set; }

        public int? nPackingTime { get; set; }
    }
}
