using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminProductsFunctions
    {
        void Edit(Product product);
        void Delete(int productId);
        void Add(Product product);
        void Save(List<Product>productRepository);
    }
}
