using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IСompareRepository
    {
        void Add(Product product, string userId);

        public Compare TryGetByUserId(string userId);
    }
}
