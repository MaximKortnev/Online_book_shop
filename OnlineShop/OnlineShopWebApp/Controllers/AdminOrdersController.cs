using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;
        public AdminOrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Info(Guid Id)
        {
            var order = ordersRepository.TryGetById(Id);
            return View(order);
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, string status) {

            ordersRepository.EditStatus(orderId, status);
            return RedirectToAction("GetOrders", "Administrator");
        }
        public IActionResult Delete(Guid orderId)
        {
            ordersRepository.Delete(orderId);
            return RedirectToAction("GetOrders", "Administrator");
        }

    }
}
