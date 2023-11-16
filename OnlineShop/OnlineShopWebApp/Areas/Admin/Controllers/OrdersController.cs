using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly IAdminOrdersFunctions adminOrders;
        private readonly IOrdersRepository ordersRepository;
        public AdminOrdersController(IAdminOrdersFunctions adminOrders, IOrdersRepository ordersRepository)
        {
            this.adminOrders = adminOrders;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Info(Guid Id)
        {
            var order = ordersRepository.TryGetById(Id);
            if (order != null) { return View(order); }
            return View("BadOrder");
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, OrderStatus status)
        {
            var order = ordersRepository.TryGetById(orderId);
            if (order != null)
            {
                adminOrders.EditStatus(orderId, status);
                return RedirectToAction("GetOrders", "Admin");
            }
            return View("BadOrder");

        }
        public IActionResult Delete(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            if (order != null)
            {
                adminOrders.Delete(orderId);
                return RedirectToAction("GetOrders", "Admin");
            }
            return View("BadOrder");

        }

    }
}
