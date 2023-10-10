using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IProductsRepository
    {
        Product TryGetProductById(int productId);
        List<Product> GetAll();
    }
}
