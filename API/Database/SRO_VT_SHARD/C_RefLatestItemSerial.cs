using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefLatestItemSerial")]
    public partial class C_RefLatestItemSerial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LatestItemSerial { get; set; }
    }
}
