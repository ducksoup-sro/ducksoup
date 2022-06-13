using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeFortressBattleRank")]
    public partial class C_RefSiegeFortressBattleRank
    {
        public byte Service { get; set; }

        [Key]
        public byte RankLvl { get; set; }

        [Required]
        [StringLength(129)]
        public string RankName { get; set; }

        public int ReqPKCount { get; set; }

        public int BindedSkillID { get; set; }

        [Required]
        [StringLength(129)]
        public string CrestPath128 { get; set; }
    }
}
