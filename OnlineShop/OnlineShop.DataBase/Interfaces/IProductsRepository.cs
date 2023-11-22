using System.Collections.Generic;
using OnlineShop.DataBase.Models;
using System;

namespace OnlineShop.DataBase.Interfaces
{
    public interface IProductsRepository
    {
        Product TryGetProductById(Guid productId);
        List<Product> GetAll();
        void Add(Product product);
    }
}
