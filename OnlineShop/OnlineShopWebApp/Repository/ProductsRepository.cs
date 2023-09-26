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
            var productCard = GetProducts().FirstOrDefault(s => s.Id == id);

            if (productCard == null) return "Такого товара нет";
            else return $"Product ID: {productCard.Id}\nName: {productCard.Name}\nCost {productCard.Cost}\nDescription: {productCard.Description}";
        }

        public static List<Product> GetProducts() => ReadProductsFromJson("wwwroot/data.json");
    }
}
