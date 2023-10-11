using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Repositories
{
    public class CompareRepository : IСompareRepository
    {

        public List<Compare> compareProducts = new List<Compare>();

        public void Add(Product product, string userId)
        {
            var existingCompare = TryGetByUserId(userId);
            if (existingCompare == null)
            {
                var newCompare = new Compare()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<Product>{ product } 
                };
                compareProducts.Add(newCompare);
            }
            else if (existingCompare.Items.FirstOrDefault(prod=> prod.Id == product.Id) == null)
            {
                existingCompare.Items.Add(product);
            }
        }

        public Compare TryGetByUserId(string userId) => compareProducts.FirstOrDefault(x => x.UserId == userId);


    }
}
