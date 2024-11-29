using KwikMedicalServer.Hubs;
using Microsoft.EntityFrameworkCore;

namespace KwikMedicalServer.Data
{
    public class KwikUserContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public KwikUserContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Configuration.GetConnectionString("KwikDB"));
            }
        }

        public DbSet<KwikUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KwikUser>()
                .ToTable("KwikUsers");

            modelBuilder.Entity<KwikUser>()
                .HasData(
                    new KwikUser
                    {
                        Id = 1,
                        Username = "Benjamin",
                        Password = "123",
                        Hospital = "Queen Margaret"
                    },
                    new KwikUser
                    {
                        Id = 2,
                        Username = "Ben",
                        Password = "123",
                        Hospital = ""
                    },
                    new KwikUser
                    {
                        Id = 3,
                        Username = "Agatha",
                        Password = "123",
                        Hospital = "Kirkaldy"
                    }
                );
        }


    }
}
