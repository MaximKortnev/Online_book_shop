using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShopWebApp.Interfaces;
using System.IO;
using System.Linq;
using System;

namespace OnlineShopWebApp.Repositories
{
    public class InFileOrdersRepository : IOrdersRepository
    {
        public List<OrderData> orders = new List<OrderData>();

        public void Add(Cart cart, string userId)
        {
            var newOrder = new OrderData()
            {
                UserId = userId,
                ListProducts = cart,
            };
            orders.Add(newOrder);
        }
        public void SaveOrders(OrderData orderData, string userId, Cart cart)
        {
            string filePath = "wwwroot/orders.json";
            var order = TryGetByUserId(Constants.UserId);
            orderData.Id = Guid.NewGuid();
            orderData.ListProducts = order.ListProducts;
            orderData.UserId = order.UserId;
            orderData.Status = "Создан";
            orderData.Data = DateTime.Now;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var existingOrders = JsonConvert.DeserializeObject<List<OrderData>>(json);
                if (existingOrders == null)
                {
                    existingOrders = new List<OrderData>
                    {
                        orderData
                    };
                }
                existingOrders.Add(orderData);
                string updatedJson = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
        public OrderData TryGetByUserId(string userId) => orders.FirstOrDefault(x => x.UserId == userId);
        public OrderData TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);

        public List<OrderData> ReadOrdersFromJson(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<OrderData>>(json);
        }
        public List<OrderData> GetAll()
        {
            var jsonFilePath = "wwwroot/orders.json";
            return File.Exists(jsonFilePath) ? ReadOrdersFromJson(jsonFilePath) : new List<OrderData> { };
        }
        public void EditStatus(Guid orderId, string status)
        {
            var orders = GetAll();
            var order = TryGetById(orderId);
            order.Status = status;
            var index = orders.FindIndex(x => x.Id == orderId);
            orders[index] = order;
            SaveAll(orders);
        }
        public void Delete(Guid orderId)
        {
            var orders = GetAll();
            orders.RemoveAt(orders.FindIndex(x => x.Id == orderId));
            SaveAll(orders);
        }
        public void SaveAll(List<OrderData> orders) {
            var filePath = "wwwroot/orders.json";
            string updatedJson = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
        
    }
}
