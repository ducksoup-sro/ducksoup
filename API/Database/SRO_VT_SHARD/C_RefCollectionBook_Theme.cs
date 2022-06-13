using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefCollectionBook_Theme")]
    public partial class C_RefCollectionBook_Theme
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public string Name128 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(129)]
        public string Desc128 { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompleteNum { get; set; }
    }
}
