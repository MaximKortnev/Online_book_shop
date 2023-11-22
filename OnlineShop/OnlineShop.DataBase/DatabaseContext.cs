using Microsoft.EntityFrameworkCore;

using OnlineShop.DataBase.Models;

namespace OnlineShop.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
