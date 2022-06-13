using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_WriteOutResetPlayTime")]
    public partial class C_WriteOutResetPlayTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LatestResetTime { get; set; }
    }
}
