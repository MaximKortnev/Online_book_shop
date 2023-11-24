using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;

namespace OnlineShop_WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartRepository, IOrdersRepository ordersRepository)
        {
            this.cartRepository = cartRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index(string userId)
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            ordersRepository.Add(cartViewModel, Constants.UserId);
            var order = ordersRepository.TryGetByUserId(Constants.UserId);

            return View(order);
        }
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");

        [HttpPost]
        public IActionResult SaveOrder(Order orderData)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", orderData);
            }
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            ordersRepository.SaveOrders(orderData, Constants.UserId, cartViewModel);
            cartRepository.Clear(Constants.UserId);
            return View("OrderSuccessfully");
        }
    }
}
