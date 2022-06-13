using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_LOG
{
    public partial class uniquekilllog
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string CharName16 { get; set; }

        [Required]
        [StringLength(255)]
        public string UniqueName { get; set; }

        public DateTime killed_at { get; set; }
    }
}
