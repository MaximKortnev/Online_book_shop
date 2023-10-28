﻿using Newtonsoft.Json;
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
            orderData.Id = new Guid();
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
    }
}
