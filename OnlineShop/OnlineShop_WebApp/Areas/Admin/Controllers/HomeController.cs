using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IOrdersRepository orderRepository;
        private readonly IRolesRepository rolesRepository;
        private readonly IUsersRepository usersRepository;
        public HomeController(IProductsRepository productRepository, IOrdersRepository orderRepository, IRolesRepository rolesRepository, IUsersRepository usersRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.rolesRepository = rolesRepository;
            this.usersRepository = usersRepository;
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
            var users = usersRepository.GetAll();
            return View(users);
        }

        public IActionResult GetRoles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }

        public IActionResult GetProducts()
        {
            var products = productRepository.GetAll();
            var productsViewModels = Mapping.ToProductViewModels(products);
            return View(productsViewModels);
        }
    }
}
