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
        if (!ConnectionStrings.ContainsKey(GetType()))
        {
            return;
        }
        optionsBuilder.UseSqlServer(
                ConnectionStrings[GetType()],
                options => options.CommandTimeout(30)
            )
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }

    public bool CanConnect()
    {
        using DuckContext db = new DuckContext();
        return db.Database.CanConnect();
    }
}