using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IComparisonRepository
    {
        void Add(ProductViewModel product, string userId);

        public Comparison TryGetByUserId(string userId);
    }
}
