using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefEvent")]
    public partial class C_RefEvent
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string DescName { get; set; }

        [StringLength(128)]
        public string ScheduleName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleCount { get; set; }
    }
}
