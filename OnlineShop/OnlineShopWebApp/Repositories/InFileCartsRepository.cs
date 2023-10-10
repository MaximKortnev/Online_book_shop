using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;
using System;
using System.IO;
using OnlineShopWebApp.Interfaces;
using Newtonsoft.Json;


namespace OnlineShopWebApp.Repositories
{
    public class InFileCartsRepository : ICartsRepository
    {
        public List<Cart> carts = new List<Cart>();

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>() { new CartItem() { Id = Guid.NewGuid(), Amount = 1, Product = product } }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCardItem = existingCart.Items.FirstOrDefault(prod => prod.Product.Id == product.Id);

                if (existingCardItem != null) existingCardItem.Amount += 1;
                else existingCart.Items.Add(new CartItem() { Id = Guid.NewGuid(), Amount = 1, Product = product });
            }
        }


        public void DecreaseAmount(Product product, string userId)
        {


            var existingCart = TryGetByUserId(userId);
            var existingCardItem = existingCart.Items.FirstOrDefault(prod => prod.Product.Id == product.Id);

            if (existingCardItem != null)
            {
                if (existingCardItem.Amount > 1) existingCardItem.Amount -= 1;
                else { existingCart.Items.Remove(existingCardItem); }
            }
            if (existingCart.Items.Count == 0) Clear();
        }


        public void Clear()
        {
            carts.Clear();
        }
        public void SaveToFileOrders(OrderData orderData, string userId)
        {
            var existingCart = TryGetByUserId(userId);
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
            Clear();
        }


        public Cart TryGetByUserId(string userId) => carts.FirstOrDefault(x => x.UserId == userId);
    }
};
