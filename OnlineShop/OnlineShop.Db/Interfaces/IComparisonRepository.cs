using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(Product product, string userId);
        public Comparison TryGetByUserId(string userId);
    }
}
