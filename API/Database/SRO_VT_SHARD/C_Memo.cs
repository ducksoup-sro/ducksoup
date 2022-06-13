using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Memo")]
    public partial class C_Memo
    {
        [Key]
        public long ID64 { get; set; }

        public int CharID { get; set; }

        [Required]
        [StringLength(64)]
        public string FromCharName { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }

        public byte Status { get; set; }

        public int? RefObjID { get; set; }

        public virtual C_Char C_Char { get; set; }
    }
}
