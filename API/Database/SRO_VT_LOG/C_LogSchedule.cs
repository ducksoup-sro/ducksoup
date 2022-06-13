using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_LogSchedule")]
    public partial class C_LogSchedule
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(124)]
        public string ServerType { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServerBodyID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(124)]
        public string ScheduleDefine { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScheduleIdx { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime OccureTime { get; set; }
    }
}
