using AbySalto.Mid.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Infrastructure.DatabaseContext
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Basket)
                .WithOne(b => b.User)
                .HasForeignKey<Basket>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // This ensures cascading save operations
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
