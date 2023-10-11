using System.Collections.Generic;
using OnlineShopWebApp.Models;
using System.Linq;
using System;
using OnlineShopWebApp.Interfaces;


namespace OnlineShopWebApp.Repositories
{
    public class InFileFavoritesRepository : IFavoritesRepository
    {
        public List<Favorite> favoriteProducts = new List<Favorite>();

        public void Add(Product product, string userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite == null)
            {
                var newCompare = new Favorite()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<Product> { product }
                };
                favoriteProducts.Add(newCompare);
            }
            else if (existingFavorite.Items.FirstOrDefault(prod => prod.Id == product.Id) == null)
            {
                existingFavorite.Items.Add(product);
            }
        }

        public void Decrease(Product product, string userId) {

            var existingFavorite = TryGetByUserId(userId);
            var existingCardItem = existingFavorite.Items.FirstOrDefault(prod => prod.Id == product.Id);

            if (existingCardItem != null) existingFavorite.Items.Remove(existingCardItem);
            if (existingFavorite.Items.Count == 0) Clear();
        }

        public void Clear() {
            favoriteProducts.Clear();
        }

        public Favorite TryGetByUserId(string userId) => favoriteProducts.FirstOrDefault(x => x.UserId == userId);
    }
};
