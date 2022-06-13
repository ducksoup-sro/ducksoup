using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrijobRanking4WEB")]
    public partial class C_TrijobRanking4WEB
    {
        [Key]
        [Column(Order = 0)]
        public byte TrijobType { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte RankType { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Rank { get; set; }

        [Required]
        [StringLength(64)]
        public string NickName { get; set; }

        public byte JobLevel { get; set; }

        public int JobData { get; set; }

        public byte IsNewEntry { get; set; }

        public short RankDelta { get; set; }

        public byte Country { get; set; }
    }
}
