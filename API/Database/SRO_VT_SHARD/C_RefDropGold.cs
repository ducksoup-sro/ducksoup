using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDropGold")]
    public partial class C_RefDropGold
    {
        [Key]
        [Column(Order = 0)]
        public byte MonLevel { get; set; }

        [Key]
        [Column(Order = 1)]
        public float DropProb { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoldMin { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoldMax { get; set; }
    }
}
