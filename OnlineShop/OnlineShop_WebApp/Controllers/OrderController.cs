using Microsoft.AspNetCore.Mvc;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Mappings;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Db;

namespace OnlineShop_WebApp.Controllers
{
    [Authorize]
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
            ViewBag.Items = cart.Items;
            ViewBag.TotalCost = Mapping.ToCartViewModel(cart).Cost;
            return View();
        }
        public IActionResult OrderSuccessfully() => View("OrderSuccessfully");

        [HttpPost]
        public IActionResult SaveOrder(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order);
            }
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            order.UserId = Constants.UserId;
            var orderDB = Mapping.ToOrderDB(order);
            orderDB.ListProducts = cart.Items;
            ordersRepository.SaveOrders(orderDB, Constants.UserId, cart);
            cartRepository.Clear(Constants.UserId);
            return View("OrderSuccessfully");
        }
    }
}
