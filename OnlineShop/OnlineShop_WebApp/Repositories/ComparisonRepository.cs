using OnlineShop_WebApp.Interfaces;
using OnlineShop_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop_WebApp.Repositories
{
    public class ComparisonRepository : IComparisonRepository
    {

        public List<Comparison> comparesonProducts = new List<Comparison>();

        public void Add(ProductViewModel product, string userId)
        {
            var existingCompareson = TryGetByUserId(userId);
            if (existingCompareson == null)
            {
                var newCompare = new Comparison()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<ProductViewModel>{ product } 
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
