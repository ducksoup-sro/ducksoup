using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_FleaMarketNetwork")]
    public partial class C_FleaMarketNetwork
    {
        [Key]
        [Column(Order = 0)]
        public byte AbleOpen { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Slot { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TidGroupID { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte ItemClass { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemCount { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte MakeZone { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cash { get; set; }

        public virtual C_Char C_Char { get; set; }
    }
}
