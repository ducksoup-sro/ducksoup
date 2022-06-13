using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("TimItemOnChar")]
    public partial class TimItemOnChar
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string CharName16 { get; set; }

        public byte? OptLevel { get; set; }

        public long? Variance { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Data { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte MagParamNum { get; set; }

        [StringLength(64)]
        public string CreaterName { get; set; }

        public long? MagParam1 { get; set; }

        public long? MagParam2 { get; set; }

        public long? MagParam3 { get; set; }

        public long? MagParam4 { get; set; }

        public long? MagParam5 { get; set; }

        public long? MagParam6 { get; set; }

        public long? MagParam7 { get; set; }

        public long? MagParam8 { get; set; }

        public long? MagParam9 { get; set; }

        public long? MagParam10 { get; set; }

        public long? MagParam11 { get; set; }

        public long? MagParam12 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Serial64 { get; set; }
    }
}
