using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace DAL
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(b => b.Code)
                .UseIdentityColumn(100000000,1);
        }
    }
}
