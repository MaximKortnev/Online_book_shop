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
            return $"Product ID: {productCard.Id}\nName: {productCard.Name}\nCost {productCard.Cost}\nDescription: {productCard.Description}";
        }

        public static List<Product> GetProducts()
        {
            var jsonFilePath = "wwwroot/data.json";

            try
            {
                List<Product> products = ReadProductsFromJson(jsonFilePath);
                return products;
            }
            catch
            {
                return new List<Product> {};
            }
        }

        public static string GetProductsData()
        {

            var productCart = "";
            var listProducts = GetProducts();

            if (ListEmpry(listProducts))
            {
                foreach (var product in listProducts)
                {
                    productCart += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
                }
                return productCart;
            }
            return "Не удалось загрузить данные.";
        }

        private static bool ListEmpry(List<Product> prod) => prod.Any();
    }
}
