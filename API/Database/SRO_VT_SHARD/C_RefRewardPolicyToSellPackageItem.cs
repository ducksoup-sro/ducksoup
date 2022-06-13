using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefRewardPolicyToSellPackageItem")]
    public partial class C_RefRewardPolicyToSellPackageItem
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Country { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string RefPackageItemCodeName { get; set; }

        public byte AcceptOrReject { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FourCC { get; set; }

        public int Param1 { get; set; }

        [Required]
        [StringLength(129)]
        public string Param1_Desc128 { get; set; }

        public int Param2 { get; set; }

        [Required]
        [StringLength(129)]
        public string Param2_Desc128 { get; set; }

        public int Param3 { get; set; }

        [Required]
        [StringLength(129)]
        public string Param3_Desc128 { get; set; }

        public int Param4 { get; set; }

        [Required]
        [StringLength(129)]
        public string Param4_Desc128 { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
