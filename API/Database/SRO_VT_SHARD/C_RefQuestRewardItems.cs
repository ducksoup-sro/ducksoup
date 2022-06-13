using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefQuestRewardItems")]
    public partial class C_RefQuestRewardItems
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string QuestCodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte RewardType { get; set; }

        [Key]
        [Column(Order = 4)]
        public string ItemCodeName { get; set; }

        [Key]
        [Column(Order = 5)]
        public string OptionalItemCode { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OptionalItemCnt { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AchieveQuantity { get; set; }

        [Key]
        [Column(Order = 8)]
        public string RentItemCodeName { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param1 { get; set; }

        [Key]
        [Column(Order = 10)]
        public string Param1_Desc { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param2 { get; set; }

        [Key]
        [Column(Order = 12)]
        public string Param2_Desc { get; set; }
    }
}
