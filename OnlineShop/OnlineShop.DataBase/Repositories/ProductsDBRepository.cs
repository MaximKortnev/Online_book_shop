using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using OnlineShop.DataBase.Models;
using OnlineShop.DataBase.Interfaces;
using OnlineShop.DataBase;

namespace OnlineShopWebApp.Repositories
{
    public class ProductsDBRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDBRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Product> ReadProductsFromJson(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }
        public Product TryGetProductById(Guid id) => databaseContext.Products.FirstOrDefault(p => p.Id == id);

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Add(Product product)
        {
            product.ImagePath = "image.jpg";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        public void Edit(Product product)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x=> x.Id == product.Id);
            if (existingProduct == null) { return; }
            existingProduct = product;
            existingProduct.ImagePath = "image.jpg";
            databaseContext.SaveChanges();
        }
    }
}
