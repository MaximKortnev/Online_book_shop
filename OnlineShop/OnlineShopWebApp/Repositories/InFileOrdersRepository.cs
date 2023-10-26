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
        public void SaveToFileOrders(OrderData orderData, string userId, Cart cart)
        {
            List<OrderData> existingOrders = new List<OrderData>();
            string filePath = "wwwroot/orders.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                existingOrders = JsonConvert.DeserializeObject<List<OrderData>>(json);
            }
            //foreach (var product in cart.Items)
            //{
            //    orderData.ListProducts += product.Product.Name + " " + product.Amount + "шт., ";
            //}

            existingOrders.Add(orderData);

            string updatedJson = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public OrderData TryGetByUserId(string userId) => orders.FirstOrDefault(x => x.UserId == userId);
    }
}
