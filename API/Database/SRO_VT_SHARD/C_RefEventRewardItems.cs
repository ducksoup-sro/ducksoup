using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefEventRewardItems")]
    public partial class C_RefEventRewardItems
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string EventCodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ItemCodeName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PayCount { get; set; }

        [Key]
        [Column(Order = 5)]
        public float AchieveRatio { get; set; }

        [Key]
        [Column(Order = 6)]
        public string RentItemCodeName { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param1 { get; set; }

        [Key]
        [Column(Order = 8)]
        public string Param1_Desc { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param2 { get; set; }

        [Key]
        [Column(Order = 10)]
        public string Param2_Desc { get; set; }
    }
}
