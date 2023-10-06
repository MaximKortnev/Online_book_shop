using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Repositories
{
    public static class ProductsRepository
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
        public static Product TryGetProductById(int id) => GetAll().FirstOrDefault(p => p.Id == id);

        public static List<Product> GetAll()
        {
            var jsonFilePath = "wwwroot/data.json";
            return File.Exists(jsonFilePath)? ReadProductsFromJson(jsonFilePath): new List<Product> {};
        }
    }
}
