using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_LatestItemSerial")]
    public partial class C_LatestItemSerial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LatestItemSerial { get; set; }
    }
}
