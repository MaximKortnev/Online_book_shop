using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IAdminProductsFunctions
    {
        void Edit(Product product, List<Product> productRepository);
        void Delete(int productId, List<Product> productRepository);
        void Add(Product product, List<Product> productRepository);
        void Save(List<Product>productRepository);
    }
}
