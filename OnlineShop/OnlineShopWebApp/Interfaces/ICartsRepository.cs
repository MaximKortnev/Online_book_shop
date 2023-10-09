using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        void DecreaseAmount(Product product, string userId);
        void Clear();
        Cart TryGetByUserId(string userId);

    }
}
