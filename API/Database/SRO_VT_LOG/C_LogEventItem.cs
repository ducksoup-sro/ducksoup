using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_LogEventItem")]
    public partial class C_LogEventItem
    {
        [Key]
        [Column(Order = 0)]
        public DateTime EventTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemRefID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dwData { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte TargetStorage { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte Operation { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte Slot_From { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte Slot_To { get; set; }

        [StringLength(64)]
        public string EventPos { get; set; }

        [StringLength(128)]
        public string strDesc { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Serial64 { get; set; }

        public long? Gold { get; set; }
    }
}
