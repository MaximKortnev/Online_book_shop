using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartRepository;

        public OrderController(ICartsRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public IActionResult Index(int userId)
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
    }
}
