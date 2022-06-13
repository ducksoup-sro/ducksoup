using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSetItemGroup")]
    public partial class C_RefSetItemGroup
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string ObjName128 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(129)]
        public string NameStrID128 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(129)]
        public string DescStrID128 { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte SetEffectMask { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SetMagicMask { get; set; }

        [Key]
        [Column("2SetMOptGroupID", Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C2SetMOptGroupID { get; set; }

        [Key]
        [Column("3SetMOptGroupID", Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C3SetMOptGroupID { get; set; }

        [Key]
        [Column("4SetMOptGroupID", Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C4SetMOptGroupID { get; set; }

        [Key]
        [Column("5SetMOptGroupID", Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C5SetMOptGroupID { get; set; }

        [Key]
        [Column("6SetMOptGroupID", Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C6SetMOptGroupID { get; set; }

        [Key]
        [Column("7SetMOptGroupID", Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C7SetMOptGroupID { get; set; }

        [Key]
        [Column("8SetMOptGroupID", Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C8SetMOptGroupID { get; set; }

        [Key]
        [Column("9SetMOptGroupID", Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C9SetMOptGroupID { get; set; }

        [Key]
        [Column("10SetMOptGroupID", Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C10SetMOptGroupID { get; set; }

        [Key]
        [Column("11SetMOptGroupID", Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C11SetMOptGroupID { get; set; }
    }
}
