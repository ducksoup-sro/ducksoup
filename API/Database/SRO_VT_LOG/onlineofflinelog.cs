using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("onlineofflinelog")]
    public partial class onlineofflinelog
    {
        public long id { get; set; }

        public int CharID { get; set; }

        public byte status { get; set; }
    }
}
