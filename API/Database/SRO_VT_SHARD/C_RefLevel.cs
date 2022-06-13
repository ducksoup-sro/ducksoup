using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefLevel")]
    public partial class C_RefLevel
    {
        [Key]
        public byte Lvl { get; set; }

        public long Exp_C { get; set; }

        public int Exp_M { get; set; }

        public int Cost_M { get; set; }

        public int Cost_ST { get; set; }

        public int GUST_Mob_Exp { get; set; }

        public int? JobExp_Trader { get; set; }

        public int? JobExp_Robber { get; set; }

        public int? JobExp_Hunter { get; set; }
    }
}
