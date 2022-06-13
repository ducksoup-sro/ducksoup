using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_FortressStatus")]
    public partial class C_FortressStatus
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string status { get; set; }

        public DateTime date { get; set; }
    }
}
