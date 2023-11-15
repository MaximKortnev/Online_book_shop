using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrdersRepository
    {
        void SaveOrders(Order orderData, string userId, Cart existingCart);
        Order TryGetByUserId(string userId);
        void Add(Cart cart, string userId);
        List<Order> GetAll();
        Order TryGetById(Guid Id);
    }
}
