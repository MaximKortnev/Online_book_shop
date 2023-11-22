using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Interfaces
{
    public interface ICartsRepository
    {
        void Add(ProductViewModel product, string userId);
        void DecreaseAmount(ProductViewModel product, string userId);
        void Clear();
        Cart TryGetByUserId(string userId);

    }
}
