using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("loginhistory")]
    public partial class loginhistory
    {
        public long id { get; set; }

        public int CharID { get; set; }

        public byte status { get; set; }

        public DateTime created_at { get; set; }
    }
}
