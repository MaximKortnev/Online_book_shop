using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Areas.Admin
{
    public class AdminProductsFunctions : IAdminProductsFunctions
    {
        private readonly IProductsRepository productRepository;

        public AdminProductsFunctions(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Edit(Product product)
        {
            var products = productRepository.GetAll();
            product.ImagePath = "image.jpg";
            products[products.FindIndex(x=>x.Id == product.Id)] = product;
            Save(products);
        }
        public void Delete(int productId)
        {
            var products = productRepository.GetAll();
            products.RemoveAt(products.FindIndex(x => x.Id == productId));
            Save(products);
        }
        public void Add(Product product)
        {
            var products = productRepository.GetAll();
            product.ImagePath = "image.jpg";
            products.Add(product);
            Save(products);
        }

        public void Save(List<Product> productRepository)
        {
            var filePath = "wwwroot/data.json";
            string updatedJson = JsonConvert.SerializeObject(productRepository, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
