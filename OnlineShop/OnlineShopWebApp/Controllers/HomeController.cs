using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System.Linq;
using OnlineShop.DataBase.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index() => View(productsRepository.GetAll());

        [HttpPost]
        public IActionResult Search(string productName)
        {
            var product = productsRepository.GetAll().Where(p => p.Name.Contains(productName)).ToList();
            if (product == null) { View("ErrorPdoduct", "Product"); }
            return View(product);
        }
    }
}