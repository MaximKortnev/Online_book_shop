﻿using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp.Areas.Admin
{
    public class AdminOrdersFunctions : IAdminOrdersFunctions
    {
        private readonly IOrdersRepository orderRepository;

        public AdminOrdersFunctions(IOrdersRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void EditStatus(Guid orderId, OrderStatus status)
        {
            var orders = orderRepository.GetAll();
            var order = orderRepository.TryGetById(orderId);
            order.Status = status;
            var index = orders.FindIndex(x => x.Id == orderId);
            orders[index] = order;
            SaveAll(orders);
        }
        public void Delete(Guid orderId)
        {
            var orders = orderRepository.GetAll();
            orders.RemoveAt(orders.FindIndex(x => x.Id == orderId));
            SaveAll(orders);
        }
        public void SaveAll(List<Order> orders)
        {
            var filePath = "wwwroot/orders.json";
            string updatedJson = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
