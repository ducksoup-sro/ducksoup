using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMagicOptGroup")]
    public partial class C_RefMagicOptGroup
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LinkID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte MagicType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MOptID { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte MOptLevel { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Value { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param1 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(129)]
        public string Param1_Desc { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Param2 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(129)]
        public string Param2_Desc { get; set; }
    }
}
