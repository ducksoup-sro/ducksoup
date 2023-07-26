namespace Database.VSRO188.SRO_VT_ACCOUNT;

public partial class _LoginLogoutStatistic
{
    public int nIdx { get; set; }

    public int nJID { get; set; }

    public int nIP { get; set; }

    public DateTime dLogin { get; set; }

    public DateTime dLogout { get; set; }

    public byte byReserved { get; set; }
}
