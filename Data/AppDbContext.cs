using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Country>().ToTable("Countries");

            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "Tech Corp" },
                new Company { CompanyId = 2, CompanyName = "Innovate LLC" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "USA" },
                new Country { CountryId = 2, CountryName = "Canada" }
            );
        }
    }
}
