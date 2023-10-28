using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Admin
{
    public class AdminOrdersFunctions : IAdminOrdersFunctions
    {
        public List<OrderData> ReadOrdersFromJson(string filePath)
        {
            var json = "";

            using (StreamReader reader = new StreamReader(filePath))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<OrderData>>(json);
        }
        public OrderData TryGetById(Guid Id) => GetAll().FirstOrDefault(x => x.Id == Id);
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
        public void SaveAll(List<OrderData> orders)
        {
            var filePath = "wwwroot/orders.json";
            string updatedJson = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }
    }
}
