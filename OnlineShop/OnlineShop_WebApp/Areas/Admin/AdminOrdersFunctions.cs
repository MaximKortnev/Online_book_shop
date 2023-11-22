using Newtonsoft.Json;
using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OnlineShop_WebApp.Areas.Admin
{
    public class AdminOrdersFunctions : IAdminOrdersFunctions
    {
        private readonly IOrdersRepository ordersRepository;

        public AdminOrdersFunctions(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public void EditStatus(Guid orderId, OrderStatus status)
        {
            var orders = ordersRepository.GetAll();
            var order = ordersRepository.TryGetById(orderId);
            order.Status = status;
            var index = orders.FindIndex(x => x.Id == orderId);
            orders[index] = order;
            SaveAll(orders);
        }
        public void Delete(Guid orderId)
        {
            var orders = ordersRepository.GetAll();
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
