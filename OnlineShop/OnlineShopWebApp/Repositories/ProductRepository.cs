using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

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
            var jsonFilePath = "wwwroot/data.json";

            try
            {
                List<Product> products = ReadProductsFromJson(jsonFilePath);
                return products;
            }
            catch 
            {
                return null;
            }
        }

        public static string GetProductsData() {

            var productCart = "";
            var listProducts = ProductRepository.GetProducts();

            if (listProducts != null) { 
                foreach (var product in listProducts)
                {
                    productCart += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
                }
                return productCart;
            }
            return "Ну удалось загрузить данные.";
        }
    }
}
