namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class tb_paygate_tran
{
    public int trans_ID { get; set; }

    public DateTime? trans_date { get; set; }

    public string? trans_type { get; set; }

    public string? bank_id { get; set; }

    public string? account_id { get; set; }

    public string? order_no { get; set; }

    public int? moneyValue { get; set; }

    public int? beforeMoney { get; set; }

    public int? afterMoney { get; set; }

    public long? PG_TransID { get; set; }
}
