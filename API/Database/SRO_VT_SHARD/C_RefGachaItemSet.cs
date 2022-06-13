using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGachaItemSet")]
    public partial class C_RefGachaItemSet
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Set_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Ratio { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Count { get; set; }

        [Key]
        [Column(Order = 5)]
        public int GachaID { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte Visible { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param1 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(129)]
        public string param1_Desc128 { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param2 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(129)]
        public string param2_Desc128 { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param3 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(129)]
        public string param3_Desc128 { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param4 { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(129)]
        public string param4_Desc128 { get; set; }
    }
}
