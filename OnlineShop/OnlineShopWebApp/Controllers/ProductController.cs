using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var productCard = ProductsRepository.TryGetProductById(id);

            if (productCard == null) { return View("Error");}
            return View(productCard);
        }
    }
}
