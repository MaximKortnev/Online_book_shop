using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;
using System;
using OnlineShopWebApp.Interfaces;

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
        public Cart TryGetByUserId(string userId) => carts.FirstOrDefault(x => x.UserId == userId);
    }
};
