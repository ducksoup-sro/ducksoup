using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_InventoryForAvatar")]
    public partial class C_InventoryForAvatar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Slot { get; set; }

        public long ItemID { get; set; }

        public virtual C_Char C_Char { get; set; }

        public virtual C_Items C_Items { get; set; }
    }
}
