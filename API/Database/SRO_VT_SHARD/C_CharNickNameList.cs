using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharNickNameList")]
    public partial class C_CharNickNameList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string NickName16 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }
    }
}
