using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("sro_servers_vt.__StatisticsGoldIncrementData__")]
    public partial class C__StatisticsGoldIncrementData__
    {
        [Key]
        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long? Paid { get; set; }

        public long? Income { get; set; }

        public long? HunterProfit { get; set; }
    }
}
