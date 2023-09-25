using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Controllers
{
    public static class ProductRepository
    {
        public static List<Product> ReadProductsFromJson(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public static List<Product> GetProducts()
        {
            var jsonFilePath = "data.json";
            List<Product> products = ProductRepository.ReadProductsFromJson(jsonFilePath);
            return products;
        }
    }
}
