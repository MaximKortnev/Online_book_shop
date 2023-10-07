using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsRepository productsRepository;
        public HomeController(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index() => View(productsRepository.GetAll());
    }
}