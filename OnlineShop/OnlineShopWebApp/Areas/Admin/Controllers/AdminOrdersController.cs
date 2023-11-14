﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Save(Guid orderId, OrderStatus status)
        {

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
