using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_OnlineOffline")]
    public partial class C_OnlineOffline
    {
        [Key]
        [Column("No.")]
        public int No_ { get; set; }

        public int CharID { get; set; }

        [Required]
        [StringLength(64)]
        public string Charname { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime Date { get; set; }

        public long? Minutes { get; set; }

        public long? tMinutes { get; set; }

        public int? eSilk { get; set; }

        public string mOnline { get; set; }

        [Column("Silk/Hour")]
        public int Silk_Hour { get; set; }

        [Column("stillOnline@")]
        public DateTime? stillOnline_ { get; set; }

        public int? Support { get; set; }
    }
}
