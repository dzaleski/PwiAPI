using Microsoft.EntityFrameworkCore;
using PwiAPI.Models;

namespace PwiAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductsOrders> ProductsOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<ProductsOrders>().HasKey(cf => new { cf.OrderId, cf.ProductId });

            modelBuilder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("getdate()").IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
