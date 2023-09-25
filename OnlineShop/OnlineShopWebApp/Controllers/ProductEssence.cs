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
    }
}
