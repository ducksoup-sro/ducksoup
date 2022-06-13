using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefCharDefault_Quest")]
    public partial class C_RefCharDefault_Quest
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Race { get; set; }

        [Key]
        [Column(Order = 3)]
        public string CodeName { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte RequiredLevel { get; set; }
    }
}
