using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_SilkGoods
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string GoodsCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string GoodsName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SilkQuantity { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PointQuantity { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SilkPrice { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte Category { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(36)]
        public string CPName { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime RegDate { get; set; }
    }
}
