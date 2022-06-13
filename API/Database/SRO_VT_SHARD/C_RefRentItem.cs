using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefRentItem")]
    public partial class C_RefRentItem
    {
        public int service { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(129)]
        public string RentCodeName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemID { get; set; }

        public byte CanDelete { get; set; }

        public byte CnaRecharge { get; set; }

        public int? RentType { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StartTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndTime { get; set; }

        public byte? TimeCnt { get; set; }

        public int? Time1 { get; set; }

        public int? Time2 { get; set; }

        public int? Time3 { get; set; }

        public int? Time4 { get; set; }

        public int? Time5 { get; set; }
    }
}
