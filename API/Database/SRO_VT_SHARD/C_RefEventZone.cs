using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefEventZone")]
    public partial class C_RefEventZone
    {
        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string ZoneName { get; set; }

        [Required]
        [StringLength(128)]
        public string EventName { get; set; }

        public int? Param1 { get; set; }

        public int? Param2 { get; set; }

        public int? Param3 { get; set; }

        public int? Param4 { get; set; }

        public int? Param5 { get; set; }

        [StringLength(128)]
        public string strParam1 { get; set; }

        [StringLength(128)]
        public string strParam2 { get; set; }

        [StringLength(128)]
        public string strParam3 { get; set; }

        [StringLength(128)]
        public string strParam4 { get; set; }

        [StringLength(128)]
        public string strParam5 { get; set; }
    }
}
