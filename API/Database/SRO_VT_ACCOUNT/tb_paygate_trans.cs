using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class tb_paygate_trans
    {
        [Key]
        public int trans_ID { get; set; }

        public DateTime? trans_date { get; set; }

        [StringLength(25)]
        public string trans_type { get; set; }

        [StringLength(15)]
        public string bank_id { get; set; }

        [StringLength(15)]
        public string account_id { get; set; }

        [StringLength(25)]
        public string order_no { get; set; }

        public int? moneyValue { get; set; }

        public int? beforeMoney { get; set; }

        public int? afterMoney { get; set; }

        public long? PG_TransID { get; set; }
    }
}
