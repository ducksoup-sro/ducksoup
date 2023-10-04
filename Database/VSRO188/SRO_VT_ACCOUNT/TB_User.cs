namespace Database.VSRO188.SRO_VT_ACCOUNT;

public class TB_User
{
    public int JID { get; set; }

    public string StrUserID { get; set; } = null!;

    public string password { get; set; } = null!;

    public byte? Status { get; set; }

    public byte? GMrank { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? sex { get; set; }

    public string? certificate_num { get; set; }

    public string? address { get; set; }

    public string? postcode { get; set; }

    public string? phone { get; set; }

    public string? mobile { get; set; }

    public DateTime? regtime { get; set; }

    public string? reg_ip { get; set; }

    public DateTime? Time_log { get; set; }

    public int? freetime { get; set; }

    public byte sec_primary { get; set; }

    public byte sec_content { get; set; }

    public int AccPlayTime { get; set; }

    public int LatestUpdateTime_ToPlayTime { get; set; }

    public int Play123Time { get; set; }
}