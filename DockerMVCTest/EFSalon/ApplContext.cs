using Microsoft.EntityFrameworkCore;
using EFSalon;

namespace ASPEFSalon
{
        public class ApplContext : DbContext
        {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Master> Masters { get; set; } = null!;

        public ApplContext(DbContextOptions<ApplContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(e => e.ToTable("Clients"));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasData(
                    new Client { id = 1, name = "Client1", surname = "a", gender = "M" },
                    new Client { id = 2, name = "Client2", surname = "b", gender = "M" },
                    new Client { id = 3, name = "Client3", surname = "c", gender = "M" }
            );
            modelBuilder.Entity<Master>(e => e.ToTable("Masters"));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Master>().HasData(
                   new Master { id = 1, name = "Master1", surname = "a", gender = "M" },
                   new Master { id = 2, name = "Master2", surname = "b", gender = "M" },
                   new Master { id = 3, name = "Master3", surname = "c", gender = "M" },
                    new Master { id = 4, name = "Master4", surname = "d", gender = "M" }
           );
        }
    }
}
