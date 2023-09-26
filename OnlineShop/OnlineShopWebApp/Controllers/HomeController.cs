using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            var productCard = "";

            foreach (var product in ProductsRepository.GetProducts())
            {
                productCard += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }
            return productCard;
        }
    }
}