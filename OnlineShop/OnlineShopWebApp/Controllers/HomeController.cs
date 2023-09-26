using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var productCart = "";

            foreach (var product in ProductRepository.GetProducts())
            {
                productCart += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }
            return productCart;
        }
    }
}
