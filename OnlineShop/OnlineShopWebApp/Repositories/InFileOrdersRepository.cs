using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShopWebApp.Interfaces;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Repositories
{
    public class InFileOrdersRepository : IOrdersRepository
    {
        public List<Order> orders = new List<Order>();

        public void AddToListOrders(Cart cart, string userId)
        {
            var newOrder = new Order()
            {
                UserId = userId,
                ListProducts = cart,
            };
            orders.Add(newOrder);
        }
        public void SaveOrder(Order orderData, string userId, Cart cart)
        {
            string filePath = "wwwroot/orders.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var existingOrders = JsonConvert.DeserializeObject<List<Order>>(json);
                if (existingOrders == null)
                {
                    existingOrders = new List<Order>
                    {
                        orderData
                    };
                }
                existingOrders.Add(orderData);
                string updatedJson = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
        }
        public Order TryGetByUserId(string userId) => orders.FirstOrDefault(x => x.UserId == userId);
    }
}
