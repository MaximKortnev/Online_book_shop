using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            var result_str = "";

            foreach (var product in ProductEssence.GetProducts())
            {
                    result_str += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }
            return result_str;
        }
    }
}