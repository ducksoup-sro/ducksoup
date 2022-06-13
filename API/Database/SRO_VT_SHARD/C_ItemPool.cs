using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_ItemPool")]
    public partial class C_ItemPool
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ItemID { get; set; }

        public byte InUse { get; set; }

        public virtual C_Items C_Items { get; set; }
    }
}
