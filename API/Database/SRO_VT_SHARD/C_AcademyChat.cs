using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_AcademyChat")]
    public partial class C_AcademyChat
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string GuardianName { get; set; }

        [StringLength(255)]
        public string CharName { get; set; }

        [StringLength(255)]
        public string Message { get; set; }

        public DateTime? Time { get; set; }

        public string IP { get; set; }
    }
}
