using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Controllers
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

        public static string SearchProductById(int id)
        {
            var ProductCard = GetProducts().FirstOrDefault(s => s.Id == id);

            if (ProductCard == null) return "Такого товара нет";
            else return $"Product ID: {ProductCard.Id}\nName: {ProductCard.Name}\nCost {ProductCard.Cost}\nDescription: {ProductCard.Description}";
        }

        public static List<Product> GetProducts()
        {
            var jsonFilePath = "data/data.json";
            List<Product> products = ReadProductsFromJson(jsonFilePath);
            return products;
        }
    }
}
