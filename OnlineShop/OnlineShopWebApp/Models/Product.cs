using Newtonsoft.Json;

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


        public override string ToString() => $"Product ID: {Id}\nName: {Name}\nCost: {Cost}";
    }
}

