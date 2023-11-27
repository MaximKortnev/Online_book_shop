using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop_WebApp.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Comparison> Comparisons { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
