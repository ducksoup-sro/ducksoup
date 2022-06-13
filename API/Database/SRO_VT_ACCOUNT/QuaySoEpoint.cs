using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("QuaySoEpoint")]
    public partial class QuaySoEpoint
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string UserCash { get; set; }

        public int? Server { get; set; }

        public int? CharID { get; set; }

        [StringLength(20)]
        public string CharName { get; set; }

        public int? SP_Own { get; set; }

        public int? SP_Before { get; set; }

        public int? SP_After { get; set; }

        public DateTime? Regdate { get; set; }

        [StringLength(2)]
        public string SourcePoint { get; set; }
    }
}
