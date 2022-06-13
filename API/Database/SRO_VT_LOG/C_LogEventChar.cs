using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_LogEventChar")]
    public partial class C_LogEventChar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime EventTime { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte EventID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Data1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Data2 { get; set; }

        [StringLength(64)]
        public string EventPos { get; set; }

        [StringLength(128)]
        public string strDesc { get; set; }
    }
}
