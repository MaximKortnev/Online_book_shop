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

        public static Product TryGetProductById(int id) => GetProducts().FirstOrDefault(p => p.Id == id);

        public static List<Product> GetProducts()
        {
            var jsonFilePath = "wwwroot/data.json";
            return File.Exists(jsonFilePath)? ReadProductsFromJson(jsonFilePath): new List<Product> { };
        }

        public static string GetAll()
        {

            var productCart = "";
            var listProducts = GetProducts();

            if (!ListEmpry(listProducts))
            {
                foreach (var product in listProducts)
                {
                    productCart += product + "\n\n";
                }
                return productCart;
            }
            return "Не удалось загрузить данные.";
        }

        private static bool ListEmpry(List<Product> prod) => !prod.Any();

       
 
    }
}
