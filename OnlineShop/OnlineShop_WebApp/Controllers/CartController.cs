using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IProductsRepository productRepository;
        public CartController(ICartsRepository cartRepository, IProductsRepository productRepository)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index(int userId)
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(Guid productId) { 
            var product = productRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddCart");}
            var productViewModel = new ProductViewModel
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

            cartRepository.Add(productViewModel, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(Guid productId)
        {
            var product = productRepository.TryGetProductById(productId);
            if (product == null) { return View("ErrorAddCart"); }
            //cartRepository.DecreaseAmount(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear() {
            cartRepository.Clear();
            return RedirectToAction("Index");
        }
    }
}
