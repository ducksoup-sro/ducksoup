using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_InvCOS")]
    public partial class C_InvCOS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COSID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Slot { get; set; }

        public long? ItemID { get; set; }

        public virtual C_CharCOS C_CharCOS { get; set; }

        public virtual C_Items C_Items { get; set; }
    }
}
