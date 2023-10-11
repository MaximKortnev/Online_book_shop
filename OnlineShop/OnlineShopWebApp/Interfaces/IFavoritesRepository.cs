using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavoritesRepository
    {
        void Add(Product product, string userId);
        void Decrease(Product product, string userId);
        void Clear();
        public Favorite TryGetByUserId(string userId);

    }
}
