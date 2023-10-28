using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly IAdminOrdersFunctions adminOrders;
        public AdminOrdersController(IAdminOrdersFunctions adminOrders)
        {
            this.adminOrders = adminOrders;
        }

        public IActionResult Info(Guid Id)
        {
            var order = adminOrders.TryGetById(Id);
            return View(order);
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, string status) {

            adminOrders.EditStatus(orderId, status);
            return RedirectToAction("GetOrders", "Administrator");
        }
        public IActionResult Delete(Guid orderId)
        {
            adminOrders.Delete(orderId);
            return RedirectToAction("GetOrders", "Administrator");
        }

    }
}
