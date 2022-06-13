using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_OldTrijob")]
    public partial class C_OldTrijob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public byte JobLvl_Trader { get; set; }

        public int Trader_Exp { get; set; }

        public byte JobLvl_Robber { get; set; }

        public int Robber_Exp { get; set; }

        public byte JobLvl_Hunter { get; set; }

        public int Hunter_Exp { get; set; }
    }
}
