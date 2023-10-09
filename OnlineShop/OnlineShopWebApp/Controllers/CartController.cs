using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IProductsReposotory productRepository;
        public CartController(ICartsRepository cartRepository, IProductsReposotory productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index(int userId)
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId) { 
            var product = productRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddCart");}
            cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(int productId)
        {
            var product = productRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddCart"); }
            cartRepository.DecreaseAmount(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
