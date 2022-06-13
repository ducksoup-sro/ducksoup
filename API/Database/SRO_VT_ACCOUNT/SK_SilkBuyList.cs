using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_SilkBuyList
    {
        [Key]
        [Column(Order = 0)]
        public int BuyNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Silk_Type { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Silk_Reason { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Silk_Offset { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Silk_Remain { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuyQuantity { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(30)]
        public string OrderNumber { get; set; }

        public byte? PGCompany { get; set; }

        public byte? PayMethod { get; set; }

        [StringLength(20)]
        public string PGUniqueNo { get; set; }

        [StringLength(14)]
        public string AuthNumber { get; set; }

        public DateTime? AuthDate { get; set; }

        public int? SubJID { get; set; }

        [StringLength(25)]
        public string srID { get; set; }

        [Key]
        [Column(Order = 9)]
        public string SlipPaper { get; set; }

        public int? MngID { get; set; }

        [StringLength(16)]
        public string IP { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime RegDate { get; set; }
    }
}
