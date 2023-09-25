using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            var ProductCard = "";

            foreach (var product in ProductsRepository.GetProducts())
            {
                ProductCard += "Product ID: " + product.Id + "\nName: " + product.Name + "\nCost " + product.Cost + "\n\n";
            }
            return ProductCard;
        }
    }
}