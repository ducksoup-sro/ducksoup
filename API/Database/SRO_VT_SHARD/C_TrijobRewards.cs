using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrijobRewards")]
    public partial class C_TrijobRewards
    {
        [Key]
        public byte JobType { get; set; }

        public long Reward { get; set; }
    }
}
