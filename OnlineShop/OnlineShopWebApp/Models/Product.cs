using Newtonsoft.Json;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("aboutTheBook")]
        public string AboutTheBook { get; set; }

        [JsonProperty("aboutAuthor")]
        public string AboutAuthor { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        public override string ToString() => $"Product ID: {Id}\nName: {Name}\nCost: {Cost}";
    }
}

