using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Controllers
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
    public static class ProductEssence
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
            
        public static string SearchProductById(int id) {

            var product_card = "";
            foreach (var product in GetProducts())
            {
                if (product.Id == id)
                {
                    product_card = "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\nDescription: " + product.Description;
                    break;
                }
                else { product_card = "Такого товара нет"; }
            }
            return product_card;
        }
            
        public static List<Product> GetProducts() {
            var jsonFilePath = "data.json";
            List<Product> products = ProductEssence.ReadProductsFromJson(jsonFilePath);
            return products;
        }
    }
}

