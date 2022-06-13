using API.Database.DuckSoup;

namespace API.Database;

public class DatabaseHelper
{
    public static string GetSettingOrDefault(string key, string defaultValue)
    {
        using var context = new Database.DuckSoup.DuckSoup();
        if (context.Settings.Any(o => o.key == key))
        {
            return context.Settings.First(s => s.key.ToLower().Equals(key)).value;
        }
        
        context.Settings.Add(new Setting {key = key, value = defaultValue});
        context.SaveChanges();
        return defaultValue;
    }
}