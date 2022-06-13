using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefQuest")]
    public partial class C_RefQuest
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Level { get; set; }

        [Key]
        [Column(Order = 4)]
        public string DescName { get; set; }

        [Key]
        [Column(Order = 5)]
        public string NameString { get; set; }

        [Key]
        [Column(Order = 6)]
        public string PayString { get; set; }

        [Key]
        [Column(Order = 7)]
        public string ContentsString { get; set; }

        [Key]
        [Column(Order = 8)]
        public string PayContents { get; set; }

        [Key]
        [Column(Order = 9)]
        public string NoticeNPC { get; set; }

        [Key]
        [Column(Order = 10)]
        public string NoticeCondition { get; set; }
    }
}
