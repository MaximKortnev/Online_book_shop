using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(ProductViewModel product, string userId);

        public Comparison TryGetByUserId(string userId);
    }
}
