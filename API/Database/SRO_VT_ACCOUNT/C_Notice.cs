using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_Notice")]
    public partial class C_Notice
    {
        public int ID { get; set; }

        public byte ContentID { get; set; }

        [Required]
        [StringLength(80)]
        public string Subject { get; set; }

        [Required]
        [StringLength(1024)]
        public string Article { get; set; }

        public DateTime EditDate { get; set; }
    }
}
