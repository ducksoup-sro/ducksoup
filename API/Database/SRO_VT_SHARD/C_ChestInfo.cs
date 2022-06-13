using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_ChestInfo")]
    public partial class C_ChestInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte ChestSize { get; set; }
    }
}
