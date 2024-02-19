using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Net.PC.Contacts.Repository.Entities;
using Net.PC.Contacts.Repository.Entities.Configuration;

namespace Net.PC.Contacts.Repository
{
    public class ContactDbContext : IdentityDbContext<User>
    {
        public ContactDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContactsDb;Trusted_Connection=True;");
        }

        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }
    }
}
