using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Repositories
{
    public class ComparisonRepository : IComparisonRepository
    {

        public List<Comparison> comparesonProducts = new List<Comparison>();

        public void Add(Product product, string userId)
        {
            var existingCompareson = TryGetByUserId(userId);
            if (existingCompareson == null)
            {
                var newCompare = new Comparison()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<Product>{ product } 
                };
                comparesonProducts.Add(newCompare);
            }
            else if (existingCompareson.Items.FirstOrDefault(prod=> prod.Id == product.Id) == null)
            {
                existingCompareson.Items.Add(product);
            }
        }

        public Comparison TryGetByUserId(string userId) => comparesonProducts.FirstOrDefault(x => x.UserId == userId);


    }
}
