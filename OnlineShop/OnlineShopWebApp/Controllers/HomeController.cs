using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var ProductCart = "";

            foreach (var product in ProductRepository.GetProducts())
            {
                ProductCart += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }
            return ProductCart;
        }
    }
}
