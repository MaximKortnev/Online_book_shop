using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

		public List<Product> Index()
		{
            string jsonFilePath = "data.json";  
            List<Product> products = ReadProductsFromJson(jsonFilePath);

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Cost: {product.Cost:C}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine();
            }
            return products;
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
