using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(Product product, string userId);

        public Comparison TryGetByUserId(string userId);
    }
}
