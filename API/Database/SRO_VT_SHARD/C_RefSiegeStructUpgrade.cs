using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeStructUpgrade")]
    public partial class C_RefSiegeStructUpgrade
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string Structname { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string BaseStructcodename { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string UpgradeStructname1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(129)]
        public string UpgradeStructname2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(129)]
        public string UpgradeStructname3 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(129)]
        public string UpgradeStructname4 { get; set; }
    }
}
