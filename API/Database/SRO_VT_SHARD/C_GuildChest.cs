using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_GuildChest")]
    public partial class C_GuildChest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuildID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Slot { get; set; }

        public long? ItemID { get; set; }

        public virtual C_Guild C_Guild { get; set; }
    }
}
