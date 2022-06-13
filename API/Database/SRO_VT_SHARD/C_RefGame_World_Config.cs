using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGame_World_Config")]
    public partial class C_RefGame_World_Config
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
        public string GroupCodeName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string ValueCodeName128 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(129)]
        public string Value { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string Type { get; set; }
    }
}
