using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.IO;
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
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<Product> ReadProductsFromJson(string filePath)
        {
            string json;

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            string jsonFilePath = "data.json";
            List<Product> products = ReadProductsFromJson(jsonFilePath);

            string result_str = "";

            foreach (var product in products)
            {
                result_str += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";

                //Console.WriteLine($"Description: {product.Description}");
            }

            return result_str;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
