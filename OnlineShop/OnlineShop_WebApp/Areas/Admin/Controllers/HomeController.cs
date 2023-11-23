using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Models;

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
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModels = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Author = product.Author,
                    AboutTheBook = product.AboutTheBook,
                    AboutAuthor = product.AboutAuthor,
                    Quote = product.Quote,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath,
                };
                productsViewModels.Add(productViewModels);
            }
            return View(productsViewModels);
        }
    }
}
