using OnlineShopWebApp.Models;
using System.Collections.Generic;

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
