using System.Data.Entity;

namespace API.Database;

public class MigrationConfig<T> : System.Data.Entity.Migrations.DbMigrationsConfiguration<T> where T : DbContext
{
    public MigrationConfig()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }
}