using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using websolutionmain.Entities;

namespace websolution.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

   


        public DbSet<Course> Courses { get; set; }
    }
}