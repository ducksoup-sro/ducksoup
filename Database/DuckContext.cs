using Microsoft.EntityFrameworkCore;

namespace Database;

public class DuckContext : DbContext
{
    public static string ConnectionString = "";

    protected DuckContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    public bool CanConnect()
    {
        using var db = new DuckContext();
        return db.Database.CanConnect();
    }
}