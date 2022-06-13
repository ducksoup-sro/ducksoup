using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_BindingOptionWithItem")]
    public partial class C_BindingOptionWithItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long nItemDBID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte bOptType { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte nSlot { get; set; }

        public int nOptID { get; set; }

        public byte nOptLvl { get; set; }

        public int nOptValue { get; set; }

        public int? nParam1 { get; set; }

        public int? nParam2 { get; set; }
    }
}
