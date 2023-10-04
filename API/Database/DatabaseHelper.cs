using API.Database.DuckSoup;

namespace API.Database;

public static class DatabaseHelper
{
    public static string GetSettingOrDefault(string key, string defaultValue)
    {
        using var context = new Context.DuckSoup();
        var setting = context.GlobalSettings.FirstOrDefault(o => o.key == key);

        if (setting != null) return setting.value;

        context.GlobalSettings.Add(new GlobalSetting { key = key, value = defaultValue });
        context.SaveChanges();
        return defaultValue;
    }
}