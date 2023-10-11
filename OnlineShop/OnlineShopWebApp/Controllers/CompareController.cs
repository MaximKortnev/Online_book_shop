using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {

        private readonly IProductsRepository productsRepository;
        private readonly IСompareRepository compareRepository;
        public CompareController(IСompareRepository compareRepository, IProductsRepository productsRepository)
        {
            this.compareRepository = compareRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var compare = compareRepository.TryGetByUserId(Constants.UserId);
            return View(compare);
        }

        public IActionResult Add(int productId) {
            var productCard = productsRepository.TryGetProductById(productId);
            compareRepository.Add(productCard, Constants.UserId);
            return RedirectToAction("Index", "Home");
        }
    }
}
