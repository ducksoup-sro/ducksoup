using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class tb_partnerInfo
    {
        [Key]
        [StringLength(10)]
        public string partnerID { get; set; }

        [StringLength(20)]
        public string partnerName { get; set; }

        [StringLength(10)]
        public string partnerPass { get; set; }

        public int? balance { get; set; }

        public DateTime? udate { get; set; }
    }
}
