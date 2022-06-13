using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_ClientConfig")]
    public partial class C_ClientConfig
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte ConfigType { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte SlotSeq { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte SlotType { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Data { get; set; }
    }
}
