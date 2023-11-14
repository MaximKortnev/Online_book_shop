using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IAdminUsersFunctions adminUsers;
        public AdminUsersController(IAdminUsersFunctions adminUsers)
        {
            this.adminUsers = adminUsers;
        }

        public IActionResult Info(Guid Id)
        {
            var order = adminUsers.TryGetById(Id);
            return View(order);
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, OrderStatus status)
        {

            adminUsers.EditStatus(orderId, status);
            return RedirectToAction("GetOrders", "Administrator");
        }
        public IActionResult Delete(Guid orderId)
        {
            adminUsers.Delete(orderId);
            return RedirectToAction("GetOrders", "Administrator");
        }
    }
}
