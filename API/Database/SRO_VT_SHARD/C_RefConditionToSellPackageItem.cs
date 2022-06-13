using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefConditionToSellPackageItem")]
    public partial class C_RefConditionToSellPackageItem
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string RefPackageItemCodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte AcceptOrReject { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FourCC { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param1 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(129)]
        public string Param1_Desc128 { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param2 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(129)]
        public string Param2_Desc128 { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param3 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(129)]
        public string Param3_Desc128 { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param4 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(129)]
        public string Param4_Desc128 { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
