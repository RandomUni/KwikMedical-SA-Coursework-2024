using KwikMedicalServer.Hubs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KwikMedicalServer.Data
{
    public class MedicalRequestResponseContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public MedicalRequestResponseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("KwikDB"));
        }

        public DbSet<MedicalRequestResponse> Response { get; set; }
    }
}
