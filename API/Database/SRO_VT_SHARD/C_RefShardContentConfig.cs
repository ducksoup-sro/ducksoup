using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefShardContentConfig")]
    public partial class C_RefShardContentConfig
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string CodeDesc128 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(129)]
        public string Value { get; set; }

        [StringLength(20)]
        public string Type { get; set; }
    }
}
