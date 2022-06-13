using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefDropOptLvlSel")]
    public partial class C_RefDropOptLvlSel
    {
        [Key]
        [Column(Order = 0)]
        public byte OptLevel { get; set; }

        [Key]
        [Column(Order = 1)]
        public float Prob { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReqOnlineTime { get; set; }
    }
}
