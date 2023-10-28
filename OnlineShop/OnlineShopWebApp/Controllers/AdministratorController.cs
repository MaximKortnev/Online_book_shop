using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IOrdersRepository orderRepository;
        public AdministratorController(IProductsRepository productRepository, IOrdersRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            var orders = orderRepository.GetAll();
            return View(orders);
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
