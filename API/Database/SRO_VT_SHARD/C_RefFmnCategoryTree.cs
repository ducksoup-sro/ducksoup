using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefFmnCategoryTree")]
    public partial class C_RefFmnCategoryTree
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CategoryName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string StringID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ParentCategoryName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TidGroupID { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte Degree { get; set; }
    }
}
