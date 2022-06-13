using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Uniques")]
    public partial class C_Uniques
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string CharName { get; set; }

        [StringLength(255)]
        public string MonsterCodeName { get; set; }

        public DateTime? Time { get; set; }
    }
}
