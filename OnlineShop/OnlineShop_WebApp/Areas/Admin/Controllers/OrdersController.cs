using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShop_WebApp.Models;
using OnlineShop.Db.Models;
using OnlineShop.Db;
using OnlineShop_WebApp.Mappings;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop_WebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        public OrdersController( IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Info(Guid Id)
        {
            var order = ordersRepository.TryGetById(Id);
            if (order != null) { return View(Mapping.ToOrderViewModel(order)); }
            return View("BadOrder");
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, OrderStatusViewModel status)
        {
            var order = ordersRepository.TryGetById(orderId);
            if (order != null)
            {
                ordersRepository.EditStatus(orderId, (OrderStatus)(OrderStatusViewModel)(int)status);
                return RedirectToAction("GetOrders", "Home");
            }
            return View("BadOrder");

        }
        public IActionResult Delete(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            if (order != null)
            {
                ordersRepository.Delete(orderId);
                return RedirectToAction("GetOrders", "Home");
            }
            return View("BadOrder");

        }

    }
}
