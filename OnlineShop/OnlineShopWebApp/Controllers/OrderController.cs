using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Net.Http;

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
            ordersRepository.Add(cart, Constants.UserId);
            var order = ordersRepository.TryGetByUserId(Constants.UserId);

            return View(order);
        }
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");


        [HttpPost]
        public IActionResult OrdersToFile([FromBody] OrderData orderData)
        {
            if (ModelState.IsValid)
            {
                var cart = cartRepository.TryGetByUserId(Constants.UserId);
                var order = ordersRepository.TryGetByUserId(Constants.UserId);
                orderData.ListProducts = order.ListProducts;
                orderData.UserId = order.UserId;
                ordersRepository.SaveOrders(orderData, Constants.UserId, cart);
                cartRepository.Clear();
                return Ok(new { message = "Order received and processed successfully."});
            }
            else { return View("BadOrder"); }
        }
    }
}
