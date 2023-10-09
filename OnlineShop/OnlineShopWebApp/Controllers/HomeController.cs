using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsReposotory productsRepository;
        public HomeController(IProductsReposotory productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index() => View(productsRepository.GetAll());
    }
}