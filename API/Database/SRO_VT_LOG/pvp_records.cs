using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_LOG
{
    public partial class pvp_records
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string CharName { get; set; }

        public long CharID { get; set; }

        [Required]
        [StringLength(255)]
        public string KilledCharName { get; set; }

        public long KilledCharID { get; set; }

        [Required]
        [StringLength(255)]
        public string type { get; set; }

        [Required]
        [StringLength(255)]
        public string position { get; set; }

        [Required]
        public string description { get; set; }

        public DateTime killed_at { get; set; }
    }
}
