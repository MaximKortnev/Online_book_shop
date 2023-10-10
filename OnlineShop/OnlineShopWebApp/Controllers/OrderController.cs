using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");


        [HttpPost]
        public IActionResult OrdersToFile([FromBody] OrderData orderData)
        {
            if (orderData == null)
            {
                return BadRequest("Invalid order data.");
            }
            cartRepository.SaveToFileOrders(orderData, Constants.UserId);
            return Ok(new { message = "Order received and processed successfully." });
        }
    }
}
