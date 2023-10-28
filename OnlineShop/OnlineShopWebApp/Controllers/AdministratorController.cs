using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductsRepository productRepository;
        public AdministratorController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            return View();
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        public IActionResult GetRoles()
        {
            return View();
        }

        public IActionResult GetProducts()
        {
            var products = productRepository.GetAll();
            return View(products);
        }
    }
}
