using Microsoft.EntityFrameworkCore;

namespace Database;

public class DuckContext : DbContext
{
    public static Dictionary<Type, string> ConnectionStrings = new Dictionary<Type, string>();

    protected DuckContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ConnectionStrings.ContainsKey(this.GetType()))
        {
            optionsBuilder.UseSqlServer(ConnectionStrings[this.GetType()]);
        }
    }

    public bool CanConnect()
    {
        using var db = new DuckContext();
        return db.Database.CanConnect();
    }
}