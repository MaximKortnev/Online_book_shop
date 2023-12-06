using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

namespace OnlineShop_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        public HomeController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            var productsViewModels = Mapping.ToProductViewModels(products);
            return View(productsViewModels);
        }

        [HttpPost]
        public IActionResult Search(string productName)
        {
            var products = productsRepository.Search(productName);
            if (products == null) { View("ErrorPdoduct", "Product"); }
            var productsViewModels = Mapping.ToProductViewModels(products);
            return View(productsViewModels);
        }
    }
}