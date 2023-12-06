using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;
using OnlineShop_WebApp.Models;
using OnlineShop.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IOrdersRepository orderRepository;
        private readonly IRolesRepository rolesRepository;
        private readonly UserManager<User> usersManager;
        public HomeController(IProductsRepository productRepository, IOrdersRepository orderRepository, IRolesRepository rolesRepository, UserManager<User> usersManager)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.rolesRepository = rolesRepository;
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetOrders()
        {
            var orders = orderRepository.GetAll();
            var ordersViewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                ordersViewModel.Add(Mapping.ToOrderViewModel(order));
            }
            return View(ordersViewModel);
        }

        public IActionResult GetUsers()
        {
            var users = usersManager.Users.ToList();
            return View(users.Select(x=>x.ToUserViewModel()).ToList());
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
