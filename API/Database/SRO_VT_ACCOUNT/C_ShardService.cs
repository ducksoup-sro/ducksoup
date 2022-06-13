using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_ShardService")]
    public partial class C_ShardService
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ShardID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte ServiceType { get; set; }
    }
}
