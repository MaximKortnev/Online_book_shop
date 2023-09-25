using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var jsonFilePath = "data.json";
            List<Product> products = ProductEssence.ReadProductsFromJson(jsonFilePath);

            var result_str = "";

            foreach (var product in products)
            {
                result_str += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }

            return result_str;
        }

    }
}
