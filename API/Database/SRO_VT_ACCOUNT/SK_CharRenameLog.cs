using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_CharRenameLog
    {
        public int id { get; set; }

        public int? JID { get; set; }

        [StringLength(50)]
        public string struserid { get; set; }

        [StringLength(20)]
        public string old_char { get; set; }

        [StringLength(20)]
        public string new_char { get; set; }

        [StringLength(20)]
        public string server { get; set; }

        public DateTime? timechange { get; set; }
    }
}
