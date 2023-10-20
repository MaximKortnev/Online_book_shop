using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
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
            return View(cart);
        }
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");


        [HttpPost]
        public IActionResult OrdersToFile([FromBody] OrderData orderData)
        {
            if (orderData == null)
            {
                return BadRequest("Invalid order data.");
            }
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.SaveToFileOrders(orderData, Constants.UserId, cart);
            cartRepository.Clear();
            return Ok(new { message = "Order received and processed successfully." });
        }
    }
}
