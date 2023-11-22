using OnlineShop_WebApp.Models;
using System.Collections.Generic;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IAdminProductsFunctions
    {
        void Edit(ProductViewModel product);
        void Delete(int productId);
        //void Add(Product product);
        void Save(List<ProductViewModel>productRepository);
    }
}
