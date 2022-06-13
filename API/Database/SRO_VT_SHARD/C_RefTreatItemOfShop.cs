using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTreatItemOfShop")]
    public partial class C_RefTreatItemOfShop
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
        public string RefShopCodeName { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Cash { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte TypeID1 { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte TypeID2 { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte TypeID3 { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte TypeID4 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(129)]
        public string RefItemCodeName { get; set; }

        [Key]
        [Column(Order = 9)]
        public byte AcceptOrReject { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FourCC { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param1 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(129)]
        public string Param1_Desc128 { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param2 { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(129)]
        public string Param2_Desc128 { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param3 { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(129)]
        public string Param3_Desc128 { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param4 { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(129)]
        public string Param4_Desc128 { get; set; }

        public virtual C_RefShopObject C_RefShopObject { get; set; }
    }
}
