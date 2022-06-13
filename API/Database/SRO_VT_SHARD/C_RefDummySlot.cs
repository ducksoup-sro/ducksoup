using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDummySlot")]
    public partial class C_RefDummySlot
    {
        [Key]
        public byte cnt { get; set; }
    }
}
