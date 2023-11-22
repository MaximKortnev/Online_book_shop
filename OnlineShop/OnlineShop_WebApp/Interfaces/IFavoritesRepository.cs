﻿using OnlineShop_WebApp.Models;

namespace OnlineShop_WebApp.Interfaces
{
    public interface IFavoritesRepository
    {
        void Add(ProductViewModel product, string userId);
        void Decrease(ProductViewModel product, string userId);
        void Clear();
        public Favorite TryGetByUserId(string userId);

    }
}