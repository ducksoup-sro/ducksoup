using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharQuest")]
    public partial class C_CharQuest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestID { get; set; }

        public byte Status { get; set; }

        public short AchievementCount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime EndTime { get; set; }

        public long QuestData1 { get; set; }

        public long QuestData2 { get; set; }
    }
}
