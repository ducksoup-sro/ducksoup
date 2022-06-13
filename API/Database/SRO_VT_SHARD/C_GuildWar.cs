using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_GuildWar")]
    public partial class C_GuildWar
    {
        public int ID { get; set; }

        public byte WarType { get; set; }

        public byte VictoryPointIndex { get; set; }

        public int LodgedGold { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? WarEndTime { get; set; }

        public int Guild1 { get; set; }

        public int Guild2 { get; set; }

        public int PointGain1 { get; set; }

        public int PointGain2 { get; set; }

        public int Data1 { get; set; }

        public int Data2 { get; set; }

        public virtual C_Guild C_Guild { get; set; }

        public virtual C_Guild C_Guild1 { get; set; }
    }
}
