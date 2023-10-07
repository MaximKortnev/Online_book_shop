using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly CartsRepository cartRepository;
        private readonly ProductsRepository productRepository;
        public CartController(CartsRepository cartRepository, ProductsRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index(int id)
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
    }
}
