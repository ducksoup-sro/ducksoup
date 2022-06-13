using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_InventoryForLinkedStorage")]
    public partial class C_InventoryForLinkedStorage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long LinkedItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Slot { get; set; }

        public long ItemID { get; set; }

        public virtual C_Items C_Items { get; set; }
    }
}
