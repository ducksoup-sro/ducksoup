using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_SHARD
{
    public partial class Tab_RefRanking_TraderContribution
    {
        [Key]
        public byte Rank { get; set; }

        [Required]
        [StringLength(17)]
        public string NickName { get; set; }

        public byte JobLevel { get; set; }

        public int Contribution { get; set; }
    }
}
