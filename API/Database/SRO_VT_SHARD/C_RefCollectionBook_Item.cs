using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefCollectionBook_Item")]
    public partial class C_RefCollectionBook_Item
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string ObjName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string ThemeCodeName128 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlotIndex { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(129)]
        public string Story128 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(129)]
        public string DDJFile128 { get; set; }
    }
}
