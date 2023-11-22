using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;

namespace OnlineShop_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index() => View();//productsRepository.GetAll());

        [HttpPost]
        public IActionResult Search(string productName)
        {
            var product = productsRepository.GetAll().Where(p => p.Name.Contains(productName)).ToList();
            if (product == null) { View("ErrorPdoduct", "Product"); }
            return View(product);
        }
    }
}