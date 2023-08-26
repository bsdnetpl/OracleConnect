using Microsoft.EntityFrameworkCore;

namespace OracleConnect.DB
{
    public class ConnectionOracle : DbContext
    {
        public ConnectionOracle(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        }
    }
}
