using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using OnlineShopWebApp.Interfaces;
using System.IO;

namespace OnlineShopWebApp.Repositories
{
    public class InFileOrdersRepository : IOrdersRepository
    {
        public void SaveToFileOrders(OrderData orderData, string userId, Cart cart)
        {
            var existingCart = cart;
            List<OrderData> existingOrders = new List<OrderData>();
            string filePath = "wwwroot/orders.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                existingOrders = JsonConvert.DeserializeObject<List<OrderData>>(json);
            }
            foreach (var product in existingCart.Items)
            {
                orderData.ListProducts += product.Product.Name + " " + product.Amount + "шт., ";
            }

            existingOrders.Add(orderData);

            string updatedJson = JsonConvert.SerializeObject(existingOrders, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
