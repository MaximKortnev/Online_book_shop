﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IAdminOrdersFunctions adminOrders;
        private readonly IOrdersRepository ordersRepository;
        public OrdersController(IAdminOrdersFunctions adminOrders, IOrdersRepository ordersRepository)
        {
            this.adminOrders = adminOrders;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Info(Guid Id)
        {
            var order = ordersRepository.TryGetById(Id);
            return View(order);
        }
        [HttpPost]
        public IActionResult Save(Guid orderId, OrderStatus status)
        {

            adminOrders.EditStatus(orderId, status);
            return RedirectToAction("GetOrders", "Home");
        }
        public IActionResult Delete(Guid orderId)
        {
            adminOrders.Delete(orderId);
            return RedirectToAction("GetOrders", "Home");
        }

    }
}