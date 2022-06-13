using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_SHL
    {
        [Key]
        public int idx { get; set; }

        public int JID { get; set; }

        public int COS { get; set; }

        public int CGS { get; set; }

        public int HOS { get; set; }

        public int HGS { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime event_time { get; set; }
    }
}
