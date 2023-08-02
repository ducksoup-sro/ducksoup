namespace API.Database.DuckSoup;

public partial class GlobalSetting
{
    public int SettingsId { get; set; }

    public string key { get; set; } = null!;

    public string value { get; set; } = null!;
}
