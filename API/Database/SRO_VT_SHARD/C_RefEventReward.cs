using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefEventReward")]
    public partial class C_RefEventReward
    {
        public byte Service { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Required]
        [StringLength(128)]
        public string EventCodeName { get; set; }

        public byte IsView { get; set; }

        public byte IsBasicReward { get; set; }

        public byte IsItemReward { get; set; }

        public byte IsCheckCondition { get; set; }

        public byte IsCheckCountry { get; set; }

        public byte IsCheckClass { get; set; }

        public byte IsCheckGender { get; set; }

        public int Gold { get; set; }

        public int Exp { get; set; }

        public int SPExp { get; set; }

        public int SP { get; set; }

        public byte Hwan { get; set; }

        public byte Inventory { get; set; }

        public byte ItemRewardType { get; set; }

        public byte SelectionCnt { get; set; }

        public int Param1 { get; set; }

        [Required]
        [StringLength(128)]
        public string Param1_Desc { get; set; }

        public int Param2 { get; set; }

        [Required]
        [StringLength(128)]
        public string Param2_Desc { get; set; }

        public int Param3 { get; set; }

        [Required]
        [StringLength(128)]
        public string Param3_Desc { get; set; }
    }
}
