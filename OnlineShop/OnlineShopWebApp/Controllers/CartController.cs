using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShop.DataBase.Interfaces;
using System;

namespace OnlineShopWebApp.Controllers
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
            //cartRepository.Add(product, Constants.UserId);
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
