using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class ComparisonDBRepository : IComparisonRepository
    {
        private readonly DatabaseContext databaseContext;

        public ComparisonDBRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var existingCompareson = TryGetByUserId(userId);
            if (existingCompareson == null)
            {
                var newCompare = new Comparison()
                {
                    UserId = userId,
                    Items = new List<Product>{ product } 
                };
                databaseContext.Comparisons.Add(newCompare);
            }
            else if (existingCompareson.Items.FirstOrDefault(prod=> prod.Id == product.Id) == null)
            {
                existingCompareson.Items.Add(product);
            }
            databaseContext.SaveChanges();
        }

        public Comparison TryGetByUserId(string userId) => databaseContext.Comparisons.FirstOrDefault(x => x.UserId == userId);

    }
}
