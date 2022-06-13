using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharNameList")]
    public partial class C_CharNameList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string CharName16 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }
    }
}
