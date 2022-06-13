using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace API.Database.DuckSoup
{
    public partial class DuckSoup : DbContext
    {
        public DuckSoup()
            : base(DatabaseManager.DuckSoupConnectionString)
        {
            
        }

        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Blacklist> Blacklist { get; set; }
        public virtual DbSet<Whitelist> Whitelist { get; set; }
        public virtual DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // modelBuilder.Entity<GlobalSetting>()
            //     .Property(e => e.Name)
            //     .IsUnicode(false);
        }
    }
}
