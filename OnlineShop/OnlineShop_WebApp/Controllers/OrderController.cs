using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;

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
            ordersRepository.Add(cart, Constants.UserId);
            var order = ordersRepository.TryGetByUserId(Constants.UserId);

            return View(order);
        }
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");

        [HttpPost]
        public IActionResult SaveOrder(Order orderData)
        {
            if (ModelState.IsValid)
            {
                var cart = cartRepository.TryGetByUserId(Constants.UserId);

                ordersRepository.SaveOrders(orderData, Constants.UserId, cart);
                cartRepository.Clear();
                return View("OrderSuccessfully");
            }
            else { return View("Index", orderData); }
        }
    }
}
