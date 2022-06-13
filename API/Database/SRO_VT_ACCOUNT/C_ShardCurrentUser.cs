using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_ShardCurrentUser")]
    public partial class C_ShardCurrentUser
    {
        [Key]
        public int nID { get; set; }

        public int nShardID { get; set; }

        public int nUserCount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime dLogDate { get; set; }
    }
}
