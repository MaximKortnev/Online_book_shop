using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Admin
{
    public class AdminProductsFunctions : IAdminProductsFunctions
    {
        public void Edit(Product product, List<Product> productRepository)
        {
            int index = product.Id - 1;

            product.ImagePath = "image.jpg";
            productRepository[index] = product;
            Save(productRepository);
        }
        public void Delete(int productId, List<Product> productRepository)
        {
            int index = productId - 1;
            productRepository.RemoveAt(index);
            Save(productRepository);
        }
        public void Add(Product product, List<Product> productRepository)
        {
            product.ImagePath = "image.jpg";
            productRepository.Add(product);
            Save(productRepository);
        }

        public void Save(List<Product> productRepository)
        {
            var filePath = "wwwroot/data.json";
            string updatedJson = JsonConvert.SerializeObject(productRepository, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
