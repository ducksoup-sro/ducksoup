using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMagicOptByItemOptLevel")]
    public partial class C_RefMagicOptByItemOptLevel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Link { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short RefMagicOptID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MagicOptValue { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte TooltipType { get; set; }

        [Key]
        [Column(Order = 4)]
        public string TooltipCodename { get; set; }

        public virtual C_RefMagicOpt C_RefMagicOpt { get; set; }
    }
}
