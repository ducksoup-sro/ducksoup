using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_DownLevelLog
    {
        public int id { get; set; }

        public int? JID { get; set; }

        [StringLength(20)]
        public string struserid { get; set; }

        [StringLength(20)]
        public string charname { get; set; }

        [StringLength(50)]
        public string package { get; set; }

        [StringLength(10)]
        public string newlevel { get; set; }

        [StringLength(20)]
        public string server { get; set; }

        public DateTime? timedown { get; set; }
    }
}
